﻿using AutoMapper;
using GameService.Data;
using GameService.Data.Models;
using GameService.Dtos.SignalR_Responses;
using GameService.Hubs;
using GameService.MessageBus;
using GameService.Services.Extensions;
using GameService.Services.GameTimerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Services.CharacterActions
{
    public interface IVikingActions
    {
        Task GetAvailableFortifyCapitalUses(Participants participant, string invitationLink);
        Task<VikingUseFortifyResponse> UseFortifyCapital();
    }

    public class VikingActions : IVikingActions
    {
        private readonly IHubContext<GameHub, IGameHub> hubContext;
        private readonly IDbContextFactory<DefaultContext> contextFactory;
        private readonly IMessageBusClient messageBusClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IGameTimerService gameTimerService;
        private readonly ICurrentStageQuestionService currentStageQuestionService;
        private readonly IMapper mapper;

        public VikingActions(IHubContext<GameHub, IGameHub> hubContext,
            IDbContextFactory<DefaultContext> contextFactory,
            IMessageBusClient messageBusClient,
            IHttpContextAccessor httpContextAccessor,
            IGameTimerService gameTimerService,
            ICurrentStageQuestionService currentStageQuestionService,
            IMapper mapper)
        {
            this.hubContext = hubContext;
            this.contextFactory = contextFactory;
            this.messageBusClient = messageBusClient;
            this.httpContextAccessor = httpContextAccessor;
            this.gameTimerService = gameTimerService;
            this.currentStageQuestionService = currentStageQuestionService;
            this.mapper = mapper;
        }

        public async Task<VikingUseFortifyResponse> UseFortifyCapital()
        {
            using var db = contextFactory.CreateDbContext();


            var globalUserId = httpContextAccessor.GetCurrentUserGlobalId();

            var playerGameTimer = gameTimerService.GameTimers.FirstOrDefault(e =>
                e.Data.GameInstance.Participants.FirstOrDefault(e => e.Player.UserGlobalIdentifier == globalUserId) is not null);

            if (playerGameTimer == null)
                throw new GameException("There is no open game where this player participates");

            var gm = playerGameTimer.Data.GameInstance;

            var currentRound = gm.Rounds
                .Where(x =>
                    x.GameRoundNumber == x.GameInstance.GameRoundNumber)
                .FirstOrDefault();

            var participant = gm.Participants.First(e => e.Player.UserGlobalIdentifier == globalUserId);

            if (currentRound.PvpRound == null)
                throw new GameException("This is not a pvp round");

            if (!currentRound.PvpRound.AttackedTerritory.IsCapital)
                throw new GameException("Pvp Round isn't capital");

            if (participant.GameCharacter.CharacterAbilities is not VikingCharacterAbilities vikingAbilities)
                throw new ArgumentException($"Character is {participant.GameCharacter.CharacterAbilities.CharacterType}, but VikingCharacter is expected");

            if (!vikingAbilities.IsFortifyCapitalAvailable)
                throw new ArgumentException("Viking character has reached the max number of fortify capitals");

            // Without using the viking ability the max capital rounds would be 1
            // Therefore, we can assume that if there is more than 1, then this person used it in this round

            if (currentRound.PvpRound.CapitalRounds.Count > 1)
                throw new ArgumentException("This person already used his viking ability this round.");


            var extraCapitalRound = new CapitalRound();
            currentRound.PvpRound.CapitalRounds.Add(extraCapitalRound);

            db.Update(gm);
            await db.SaveChangesAsync();

            // Request questions for these rounds
            CommonTimerFunc.RequestCapitalQuestions(messageBusClient,
                gm.GameGlobalIdentifier, new List<int>()
                {
                    extraCapitalRound.Id,
                });


            vikingAbilities.FortifyCapitalUseCount++;



            var res = currentStageQuestionService.GetCurrentStageQuestionResponse(gm);

            return new VikingUseFortifyResponse()
            {
                QuestionResponse = res,
                UsedInRoundId = currentRound.Id,
                GameLink = gm.InvitationLink
            };
        }

        public async Task GetAvailableFortifyCapitalUses(Participants participant, string invitationLink)
        {
            // Get the character
            // Check if he can use fortify capital
            // Send a message to the client with the available count


            var vikingAbilities = participant.GameCharacter.CharacterAbilities as VikingCharacterAbilities;

            var totalLeftUses = vikingAbilities.FortifyCapitalMaxUseCount - vikingAbilities.FortifyCapitalUseCount;

            await hubContext.Clients.Group(invitationLink)
                .VikingGetAbilityUsesLeft(totalLeftUses);
        }
    }
}
