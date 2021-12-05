﻿using AutoMapper;
using GameService.Context;
using GameService.Dtos.SignalR_Responses;
using GameService.Hubs;
using GameService.MessageBus;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Services.GameTimerServices
{
    public interface IPvpStageTimerEvents
    {
        // Number
        // MultipleChoice
        Task Open_Pvp_MultipleChoice_Attacker_Territory_Selecting(TimerWrapper timerWrapper);
        Task Close_Pvp_MultipleChoice_Attacker_Territory_Selecting(TimerWrapper timerWrapper);
        Task Close_Pvp_MultipleChoice_Question_Voting(TimerWrapper timerWrapper);
        Task Show_Pvp_MultipleChoice_Screen(TimerWrapper timerWrapper);
    }

    public class PvpStageTimerEvents : IPvpStageTimerEvents
    {
        private readonly IDbContextFactory<DefaultContext> contextFactory;
        private readonly IHubContext<GameHub, IGameHub> hubContext;
        private readonly IGameTerritoryService gameTerritoryService;
        private readonly IMapper mapper;
        private readonly IMessageBusClient messageBus;

        public PvpStageTimerEvents(IDbContextFactory<DefaultContext> _contextFactory,
            IHubContext<GameHub, IGameHub> hubContext,
            IGameTerritoryService gameTerritoryService,
            IMapper mapper,
            IMessageBusClient messageBus)
        {
            this.hubContext = hubContext;
            this.gameTerritoryService = gameTerritoryService;
            this.mapper = mapper;
            this.messageBus = messageBus;
            contextFactory = _contextFactory;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="timerWrapper"></param>
        /// <param name="isNeutral"></param>
        /// <returns></returns>
        public async Task Show_Pvp_MultipleChoice_Screen(TimerWrapper timerWrapper)
        {
            // Stop timer until we calculate the next action and client event
            timerWrapper.Stop();

            // Get the question and show it to the clients
            var data = timerWrapper.Data;
            var db = contextFactory.CreateDbContext();

            // Show the question to the user
            var question = await db.Questions
                .Include(x => x.Answers)
                .Include(x => x.Round)
                .ThenInclude(x => x.GameInstance)
                .ThenInclude(x => x.Participants)
                .Where(x => x.Round.GameInstanceId == data.GameInstanceId &&
                    x.Round.GameRoundNumber == x.Round.GameInstance.GameRoundNumber)
                .FirstOrDefaultAsync();


            // Open this question for voting
            question.Round.IsQuestionVotingOpen = true;
            db.Update(question.Round);
            await db.SaveChangesAsync();

            var response = mapper.Map<QuestionClientResponse>(question);

            response.IsNeutral = false;

            var participants = await db.PvpRounds
                .Include(x => x.Round)
                .ThenInclude(x => x.GameInstance)
                .ThenInclude(x => x.Participants)
                .Where(x => x.Round.GameRoundNumber == data.CurrentGameRoundNumber &&
                    x.Round.GameInstanceId == data.GameInstanceId)
                .Select(x => new
                {
                    Participants = x.Round.GameInstance.Participants
                        .Where(y => y.PlayerId == x.AttackerId || y.PlayerId == x.DefenderId)
                        .ToArray(),
                    x.AttackerId,
                    x.DefenderId,
                })
                .FirstOrDefaultAsync();

            response.Participants = participants.Participants;
            response.AttackerId = participants.AttackerId;
            response.DefenderId = participants.DefenderId ?? 0;


            await hubContext.Clients.Group(data.GameLink).GetRoundQuestion(response,
                GameActionsTime.GetServerActionsTime(ActionState.SHOW_PVP_MULTIPLE_CHOICE_QUESTION));

            timerWrapper.Data.NextAction = ActionState.END_PVP_MULTIPLE_CHOICE_QUESTION;
            timerWrapper.Interval = GameActionsTime.GetServerActionsTime(ActionState.SHOW_PVP_MULTIPLE_CHOICE_QUESTION);
            timerWrapper.Start();
        }

        ///TODO
        public async Task Close_Pvp_MultipleChoice_Question_Voting(TimerWrapper timerWrapper)
        {
            // Can disable voting on start, however even 0-1s delay wouldn't be game breaking and would ease performance
            timerWrapper.Stop();
            var data = timerWrapper.Data;
            var db = contextFactory.CreateDbContext();

            var currentRound =
                await db.Round
                .Include(x => x.GameInstance)
                .Include(x => x.Question)
                .ThenInclude(x => x.Answers)
                .Include(x => x.PvpRound)
                .ThenInclude(x => x.PvpRoundAnswers)
                .Include(x => x.PvpRound)
                .ThenInclude(x => x.AttackedTerritory)
                .Where(x => x.GameRoundNumber == data.CurrentGameRoundNumber
                    && x.GameInstanceId == data.GameInstanceId)
                .FirstOrDefaultAsync();

            currentRound.IsQuestionVotingOpen = false;

            // If attacker didn't win, we don't care what the outcome is
            var attackerAnswer = currentRound
                .PvpRound
                .PvpRoundAnswers
                .FirstOrDefault(x => x.UserId == currentRound.PvpRound.AttackerId);

            var defenderAnswer = currentRound
                .PvpRound
                .PvpRoundAnswers
                .FirstOrDefault(x => x.UserId == currentRound.PvpRound.DefenderId);


            // Attacker didn't answer, automatically loses
            if (attackerAnswer == null || attackerAnswer.MChoiceQAnswerId == null)
            {
                // Player answered incorrecly, release isattacked lock on objterritory
                currentRound.PvpRound.WinnerId = currentRound.PvpRound.DefenderId;
                currentRound.PvpRound.AttackedTerritory.AttackedBy = null;
            }
            else
            {

                var didAttackerAnswerCorrectly = currentRound
                    .Question
                    .Answers
                    .First(x => x.Id == attackerAnswer.MChoiceQAnswerId)
                    .Correct;

                if (!didAttackerAnswerCorrectly)
                {
                    // Player answered incorrecly, release isattacked lock on objterritory
                    currentRound.PvpRound.WinnerId = currentRound.PvpRound.DefenderId;
                    currentRound.PvpRound.AttackedTerritory.AttackedBy = null;
                }
                else
                {
                    // Defender didn't vote, he lost
                    if (defenderAnswer == null || defenderAnswer.MChoiceQAnswerId == null)
                    {
                        // Player answered incorrecly, release isattacked lock on objterritory
                        currentRound.PvpRound.WinnerId = currentRound.PvpRound.AttackerId;
                        currentRound.PvpRound.AttackedTerritory.AttackedBy = null;
                        currentRound.PvpRound.AttackedTerritory.TakenBy = currentRound.PvpRound.AttackerId;
                    }
                    // Both people answered correctly, show a blitz number question
                    else
                    {
                        // A new number question has to be shown
                        throw new NotImplementedException("A new number question has to be shown");
                    }
                }
            }

            timerWrapper.Data.CurrentGameRoundNumber++;
            currentRound.GameInstance.GameRoundNumber = timerWrapper.Data.CurrentGameRoundNumber;

            db.Update(currentRound);
            await db.SaveChangesAsync();

            // Client response
            var response = new MCPlayerQuestionAnswers()
            {
                CorrectAnswerId = currentRound.Question.Answers.FirstOrDefault(x => x.Correct).Id,
                PlayerAnswers = new List<PlayerIdAnswerId>()
                {
                    new PlayerIdAnswerId()
                    {
                        Id = currentRound.PvpRound.DefenderId ?? 0,
                        AnswerId = defenderAnswer?.MChoiceQAnswerId ?? 0,
                    },
                    new PlayerIdAnswerId()
                    {
                        Id = currentRound.PvpRound.AttackerId,
                        AnswerId = attackerAnswer?.MChoiceQAnswerId ?? 0,
                    }
                }
            };

            await hubContext.Clients.Groups(data.GameLink).MCQuestionPreviewResult(response);

            timerWrapper.Data.NextAction = ActionState.OPEN_PVP_PLAYER_ATTACK_VOTING;

            timerWrapper.Interval = GameActionsTime.DefaultPreviewTime;

            timerWrapper.Start();
        }

        public async Task Open_Pvp_MultipleChoice_Attacker_Territory_Selecting(TimerWrapper timerWrapper)
        {
            var data = timerWrapper.Data;
            using var db = contextFactory.CreateDbContext();

            var currentRound = await db.Round
                .Include(x => x.PvpRound)
                .ThenInclude(x => x.PvpRoundAnswers)
                .Where(x => x.GameRoundNumber == data.CurrentGameRoundNumber 
                    && x.GameInstanceId == data.GameInstanceId)
                .FirstOrDefaultAsync();

            currentRound.IsTerritoryVotingOpen = true;

            db.Update(currentRound);
            await db.SaveChangesAsync();

            var currentAttacker = currentRound.PvpRound.AttackerId;

            var availableTerritories = await gameTerritoryService
                .GetAvailableAttackTerritoriesNames(db, currentAttacker, data.GameInstanceId, false);

            await hubContext.Clients.Group(data.GameLink)
                .ShowRoundingAttacker(currentAttacker,
                    GameActionsTime.GetServerActionsTime(ActionState.OPEN_PVP_PLAYER_ATTACK_VOTING), availableTerritories);

            var fullGame = await CommonTimerFunc.GetFullGameInstance(data.GameInstanceId, db);
            await hubContext.Clients.Group(data.GameLink)
                .GetGameInstance(fullGame);

            // Set next action and interval
            timerWrapper.Data.NextAction = ActionState.CLOSE_PVP_PLAYER_ATTACK_VOTING;
            timerWrapper.Interval = GameActionsTime.GetServerActionsTime(ActionState.OPEN_PVP_PLAYER_ATTACK_VOTING);

            timerWrapper.Start();
        }

        public async Task Close_Pvp_MultipleChoice_Attacker_Territory_Selecting(TimerWrapper timerWrapper)
        {
            var data = timerWrapper.Data;
            using var db = contextFactory.CreateDbContext();

            var currentRound = await db.Round
                .Include(x => x.PvpRound)
                .ThenInclude(x => x.PvpRoundAnswers)
                .Where(x => x.GameRoundNumber == data.CurrentGameRoundNumber && x.GameInstanceId == data.GameInstanceId)
                .FirstOrDefaultAsync();

            // Player didn't select anything, assign him a random UNSELECTED territory
            if (currentRound.PvpRound.AttackedTerritoryId == null)
            {
                var randomTerritory = 
                    await gameTerritoryService.GetRandomTerritory(currentRound.PvpRound.AttackerId, data.GameInstanceId, false);

                currentRound.PvpRound.AttackedTerritoryId = randomTerritory.Id;

                currentRound.PvpRound.DefenderId = randomTerritory.TakenBy;
                randomTerritory.AttackedBy = currentRound.PvpRound.AttackerId;

                db.Update(randomTerritory);
            }

            var fullGame = await CommonTimerFunc.GetFullGameInstance(data.GameInstanceId, db);

            currentRound.IsTerritoryVotingOpen = false;
            db.Update(currentRound);
            await db.SaveChangesAsync();

            await hubContext.Clients.Group(data.GameLink)
                .GetGameInstance(fullGame);

            timerWrapper.Interval = GameActionsTime.DefaultPreviewTime;
            timerWrapper.Data.NextAction = ActionState.SHOW_PVP_MULTIPLE_CHOICE_QUESTION;
            timerWrapper.Start();
        }
    }
}
