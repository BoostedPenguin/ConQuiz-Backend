﻿// <auto-generated />
using System;
using GameService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GameService.NpgsqlMigrations.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GameService.Data.Models.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<bool>("Correct")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("GameService.Data.Models.AttackingNeutralTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("AnsweredAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("answered_at");

                    b.Property<int>("AttackOrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("attackOrderNumber");

                    b.Property<int?>("AttackedTerritoryId")
                        .HasColumnType("integer")
                        .HasColumnName("attackedTerritoryId");

                    b.Property<int>("AttackerId")
                        .HasColumnType("integer")
                        .HasColumnName("attackerId");

                    b.Property<int?>("AttackerMChoiceQAnswerId")
                        .HasColumnType("integer")
                        .HasColumnName("attackerMChoiceQAnswerId");

                    b.Property<long?>("AttackerNumberQAnswer")
                        .HasColumnType("bigint")
                        .HasColumnName("attackerNumberQAnswer");

                    b.Property<bool?>("AttackerWon")
                        .HasColumnType("boolean")
                        .HasColumnName("attackerWon");

                    b.Property<int>("NeutralRoundId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AttackedTerritoryId");

                    b.HasIndex("NeutralRoundId");

                    b.ToTable("AttackingNeutralTerritory");
                });

            modelBuilder.Entity("GameService.Data.Models.Borders", b =>
                {
                    b.Property<int>("ThisTerritory")
                        .HasColumnType("integer");

                    b.Property<int>("NextToTerritory")
                        .HasColumnType("integer");

                    b.HasKey("ThisTerritory", "NextToTerritory")
                        .HasName("pk_myConstraint");

                    b.HasIndex("NextToTerritory");

                    b.ToTable("Borders");
                });

            modelBuilder.Entity("GameService.Data.Models.CapitalRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CapitalRoundAttackStage")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isCompleted");

                    b.Property<bool>("IsQuestionVotingOpen")
                        .HasColumnType("boolean");

                    b.Property<int>("PvpRoundId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("QuestionOpenedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PvpRoundId");

                    b.ToTable("CapitalRound");
                });

            modelBuilder.Entity("GameService.Data.Models.CapitalRoundAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CapitalRoundId")
                        .HasColumnType("integer");

                    b.Property<int?>("MChoiceQAnswerId")
                        .HasColumnType("integer")
                        .HasColumnName("mChoiceQAnswerId");

                    b.Property<long?>("NumberQAnswer")
                        .HasColumnType("bigint")
                        .HasColumnName("numberQAnswer");

                    b.Property<DateTime?>("NumberQAnsweredAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("numebrQAnsweredAt");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("CapitalRoundId");

                    b.ToTable("CapitalRoundAnswers");
                });

            modelBuilder.Entity("GameService.Data.Models.GameInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("end_time");

                    b.Property<int>("GameCreatorId")
                        .HasColumnType("integer")
                        .HasColumnName("gameCreatorId");

                    b.Property<string>("GameGlobalIdentifier")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gameGlobalIdentifier");

                    b.Property<int>("GameRoundNumber")
                        .HasColumnType("integer")
                        .HasColumnName("gameRoundNumber");

                    b.Property<string>("GameState")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("IN_LOBBY");

                    b.Property<int>("GameType")
                        .HasColumnType("integer");

                    b.Property<string>("InvitationLink")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)")
                        .HasColumnName("invitationLink");

                    b.Property<int>("Mapid")
                        .HasColumnType("integer");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionTimerSeconds")
                        .HasColumnType("integer")
                        .HasColumnName("questionTimerSeconds");

                    b.Property<int>("ResultId")
                        .HasColumnType("integer")
                        .HasColumnName("resultId");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("Mapid");

                    b.HasIndex("ParticipantsId");

                    b.HasIndex("ResultId");

                    b.ToTable("GameInstance");
                });

            modelBuilder.Entity("GameService.Data.Models.MapTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MapId")
                        .HasColumnType("integer")
                        .HasColumnName("mapId");

                    b.Property<string>("TerritoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("territoryName");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("MapTerritory");
                });

            modelBuilder.Entity("GameService.Data.Models.Maps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("GameService.Data.Models.NeutralRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AttackOrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("attackOrderNumber");

                    b.Property<int>("RoundId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("NeutralRound");
                });

            modelBuilder.Entity("GameService.Data.Models.ObjectTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AttackedBy")
                        .HasColumnType("integer")
                        .HasColumnName("attackedBy");

                    b.Property<int>("GameInstanceId")
                        .HasColumnType("integer")
                        .HasColumnName("gameInstanceId");

                    b.Property<bool>("IsCapital")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isCapital");

                    b.Property<int>("MapTerritoryId")
                        .HasColumnType("integer")
                        .HasColumnName("mapTerritoryId");

                    b.Property<int?>("TakenBy")
                        .HasColumnType("integer")
                        .HasColumnName("takenBy");

                    b.Property<int>("TerritoryScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("territoryScore");

                    b.HasKey("Id");

                    b.HasIndex("GameInstanceId");

                    b.HasIndex("MapTerritoryId");

                    b.ToTable("ObjectTerritory");
                });

            modelBuilder.Entity("GameService.Data.Models.Participants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasDefaultValue("penguinAvatar.svg")
                        .HasColumnName("avatarName");

                    b.Property<int>("FinalQuestionScore")
                        .HasColumnType("integer");

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameId");

                    b.Property<bool>("IsBot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isBot");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer")
                        .HasColumnName("playerId");

                    b.Property<int>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("GameService.Data.Models.PvpRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AttackedTerritoryId")
                        .HasColumnType("integer")
                        .HasColumnName("attackedTerritoryId");

                    b.Property<int>("AttackerId")
                        .HasColumnType("integer")
                        .HasColumnName("attackerId");

                    b.Property<int?>("DefenderId")
                        .HasColumnType("integer")
                        .HasColumnName("defenderId");

                    b.Property<bool>("IsCurrentlyCapitalStage")
                        .HasColumnType("boolean");

                    b.Property<int>("RoundId")
                        .HasColumnType("integer");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("integer")
                        .HasColumnName("winnerId");

                    b.HasKey("Id");

                    b.HasIndex("AttackedTerritoryId");

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("PvpRounds");
                });

            modelBuilder.Entity("GameService.Data.Models.PvpRoundAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MChoiceQAnswerId")
                        .HasColumnType("integer")
                        .HasColumnName("mChoiceQAnswerId");

                    b.Property<long?>("NumberQAnswer")
                        .HasColumnType("bigint")
                        .HasColumnName("numberQAnswer");

                    b.Property<DateTime?>("NumberQAnsweredAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PvpRoundId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("PvpRoundId");

                    b.ToTable("PvpRoundAnswers");
                });

            modelBuilder.Entity("GameService.Data.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CapitalRoundMCId")
                        .HasColumnType("integer");

                    b.Property<int?>("CapitalRoundNumberId")
                        .HasColumnType("integer");

                    b.Property<int?>("PvpRoundId")
                        .HasColumnType("integer");

                    b.Property<string>("Question")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("question");

                    b.Property<int?>("RoundId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("CapitalRoundMCId")
                        .IsUnique();

                    b.HasIndex("CapitalRoundNumberId")
                        .IsUnique();

                    b.HasIndex("PvpRoundId")
                        .IsUnique();

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GameService.Data.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AttackStage")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("MULTIPLE_NEUTRAL");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<int>("GameInstanceId")
                        .HasColumnType("integer")
                        .HasColumnName("gameInstanceId");

                    b.Property<int>("GameRoundNumber")
                        .HasColumnType("integer")
                        .HasColumnName("gameRoundNumber");

                    b.Property<bool>("IsQuestionVotingOpen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isQuestionVotingOpen");

                    b.Property<bool>("IsTerritoryVotingOpen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isTerritoryVotingOpen");

                    b.Property<DateTime?>("QuestionOpenedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GameInstanceId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("GameService.Data.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsInGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("isInGame");

                    b.Property<string>("UserGlobalIdentifier")
                        .HasColumnType("text")
                        .HasColumnName("userGlobalIdentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameService.Data.Models.Answers", b =>
                {
                    b.HasOne("GameService.Data.Models.Questions", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("GameService.Data.Models.AttackingNeutralTerritory", b =>
                {
                    b.HasOne("GameService.Data.Models.ObjectTerritory", "AttackedTerritory")
                        .WithMany("NeutralRoundsAttacks")
                        .HasForeignKey("AttackedTerritoryId")
                        .HasConstraintName("FK__attTer__neuAtt__8AJAWDSW");

                    b.HasOne("GameService.Data.Models.NeutralRound", "NeutralRound")
                        .WithMany("TerritoryAttackers")
                        .HasForeignKey("NeutralRoundId")
                        .HasConstraintName("FK__NeuRound__terAtt__8AWDJXCS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttackedTerritory");

                    b.Navigation("NeutralRound");
                });

            modelBuilder.Entity("GameService.Data.Models.Borders", b =>
                {
                    b.HasOne("GameService.Data.Models.MapTerritory", "NextToTerritoryNavigation")
                        .WithMany("BordersNextToTerritoryNavigation")
                        .HasForeignKey("NextToTerritory")
                        .HasConstraintName("FK_Borders_MapTerritory1")
                        .IsRequired();

                    b.HasOne("GameService.Data.Models.MapTerritory", "ThisTerritoryNavigation")
                        .WithMany("BordersThisTerritoryNavigation")
                        .HasForeignKey("ThisTerritory")
                        .HasConstraintName("FK_Borders_MapTerritory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextToTerritoryNavigation");

                    b.Navigation("ThisTerritoryNavigation");
                });

            modelBuilder.Entity("GameService.Data.Models.CapitalRound", b =>
                {
                    b.HasOne("GameService.Data.Models.PvpRound", "PvpRound")
                        .WithMany("CapitalRounds")
                        .HasForeignKey("PvpRoundId")
                        .HasConstraintName("FK__capitalRou__pvpRound__JAWD2")
                        .IsRequired();

                    b.Navigation("PvpRound");
                });

            modelBuilder.Entity("GameService.Data.Models.CapitalRoundAnswers", b =>
                {
                    b.HasOne("GameService.Data.Models.CapitalRound", "CapitalRound")
                        .WithMany("CapitalRoundUserAnswers")
                        .HasForeignKey("CapitalRoundId")
                        .IsRequired();

                    b.Navigation("CapitalRound");
                });

            modelBuilder.Entity("GameService.Data.Models.GameInstance", b =>
                {
                    b.HasOne("GameService.Data.Models.Maps", "Map")
                        .WithMany("GameInstance")
                        .HasForeignKey("Mapid")
                        .HasConstraintName("FK_GameInstance_Maps")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("GameService.Data.Models.MapTerritory", b =>
                {
                    b.HasOne("GameService.Data.Models.Maps", "Map")
                        .WithMany("MapTerritory")
                        .HasForeignKey("MapId")
                        .HasConstraintName("FK_MapTerritory_Maps")
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("GameService.Data.Models.NeutralRound", b =>
                {
                    b.HasOne("GameService.Data.Models.Round", "Round")
                        .WithOne("NeutralRound")
                        .HasForeignKey("GameService.Data.Models.NeutralRound", "RoundId")
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("GameService.Data.Models.ObjectTerritory", b =>
                {
                    b.HasOne("GameService.Data.Models.GameInstance", "GameInstance")
                        .WithMany("ObjectTerritory")
                        .HasForeignKey("GameInstanceId")
                        .HasConstraintName("FK__ObjectTer__gameIn__5AEE82B9")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.Data.Models.MapTerritory", "MapTerritory")
                        .WithMany("ObjectTerritory")
                        .HasForeignKey("MapTerritoryId")
                        .HasConstraintName("FK__ObjectTer__mapTe__59FA5E80")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameInstance");

                    b.Navigation("MapTerritory");
                });

            modelBuilder.Entity("GameService.Data.Models.Participants", b =>
                {
                    b.HasOne("GameService.Data.Models.GameInstance", "Game")
                        .WithMany("Participants")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK__Participa__gameI__5812160E")
                        .IsRequired();

                    b.HasOne("GameService.Data.Models.Users", "Player")
                        .WithMany("Participants")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Participa__playe__571DF1D5")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GameService.Data.Models.PvpRound", b =>
                {
                    b.HasOne("GameService.Data.Models.ObjectTerritory", "AttackedTerritory")
                        .WithMany("PvpRounds")
                        .HasForeignKey("AttackedTerritoryId");

                    b.HasOne("GameService.Data.Models.Round", "Round")
                        .WithOne("PvpRound")
                        .HasForeignKey("GameService.Data.Models.PvpRound", "RoundId")
                        .IsRequired();

                    b.Navigation("AttackedTerritory");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("GameService.Data.Models.PvpRoundAnswers", b =>
                {
                    b.HasOne("GameService.Data.Models.PvpRound", "PvpRound")
                        .WithMany("PvpRoundAnswers")
                        .HasForeignKey("PvpRoundId")
                        .HasConstraintName("FK__pvpRou__pvpRouAns__A8AWDJBNS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PvpRound");
                });

            modelBuilder.Entity("GameService.Data.Models.Questions", b =>
                {
                    b.HasOne("GameService.Data.Models.CapitalRound", "CapitalRoundMultiple")
                        .WithOne("CapitalRoundMultipleQuestion")
                        .HasForeignKey("GameService.Data.Models.Questions", "CapitalRoundMCId");

                    b.HasOne("GameService.Data.Models.CapitalRound", "CapitalRoundNumber")
                        .WithOne("CapitalRoundNumberQuestion")
                        .HasForeignKey("GameService.Data.Models.Questions", "CapitalRoundNumberId");

                    b.HasOne("GameService.Data.Models.PvpRound", "PvpRoundNum")
                        .WithOne("NumberQuestion")
                        .HasForeignKey("GameService.Data.Models.Questions", "PvpRoundId");

                    b.HasOne("GameService.Data.Models.Round", "Round")
                        .WithOne("Question")
                        .HasForeignKey("GameService.Data.Models.Questions", "RoundId");

                    b.Navigation("CapitalRoundMultiple");

                    b.Navigation("CapitalRoundNumber");

                    b.Navigation("PvpRoundNum");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("GameService.Data.Models.Round", b =>
                {
                    b.HasOne("GameService.Data.Models.GameInstance", "GameInstance")
                        .WithMany("Rounds")
                        .HasForeignKey("GameInstanceId")
                        .HasConstraintName("FK__Round__gameI__5CD6CB2B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameInstance");
                });

            modelBuilder.Entity("GameService.Data.Models.CapitalRound", b =>
                {
                    b.Navigation("CapitalRoundMultipleQuestion");

                    b.Navigation("CapitalRoundNumberQuestion");

                    b.Navigation("CapitalRoundUserAnswers");
                });

            modelBuilder.Entity("GameService.Data.Models.GameInstance", b =>
                {
                    b.Navigation("ObjectTerritory");

                    b.Navigation("Participants");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("GameService.Data.Models.MapTerritory", b =>
                {
                    b.Navigation("BordersNextToTerritoryNavigation");

                    b.Navigation("BordersThisTerritoryNavigation");

                    b.Navigation("ObjectTerritory");
                });

            modelBuilder.Entity("GameService.Data.Models.Maps", b =>
                {
                    b.Navigation("GameInstance");

                    b.Navigation("MapTerritory");
                });

            modelBuilder.Entity("GameService.Data.Models.NeutralRound", b =>
                {
                    b.Navigation("TerritoryAttackers");
                });

            modelBuilder.Entity("GameService.Data.Models.ObjectTerritory", b =>
                {
                    b.Navigation("NeutralRoundsAttacks");

                    b.Navigation("PvpRounds");
                });

            modelBuilder.Entity("GameService.Data.Models.PvpRound", b =>
                {
                    b.Navigation("CapitalRounds");

                    b.Navigation("NumberQuestion");

                    b.Navigation("PvpRoundAnswers");
                });

            modelBuilder.Entity("GameService.Data.Models.Questions", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("GameService.Data.Models.Round", b =>
                {
                    b.Navigation("NeutralRound");

                    b.Navigation("PvpRound");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("GameService.Data.Models.Users", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
