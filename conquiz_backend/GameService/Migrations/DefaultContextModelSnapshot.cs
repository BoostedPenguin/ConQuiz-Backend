﻿// <auto-generated />
using System;
using GameService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameService.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameService.Models.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("answer");

                    b.Property<bool>("Correct")
                        .HasColumnType("bit")
                        .HasColumnName("correct");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("questionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("GameService.Models.AttackingNeutralTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttackedTerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("attackedTerritoryId");

                    b.Property<int>("AttackerId")
                        .HasColumnType("int")
                        .HasColumnName("attackerId");

                    b.Property<int?>("AttackerMChoiceQAnswerId")
                        .HasColumnType("int")
                        .HasColumnName("attackerMChoiceQAnswerId");

                    b.Property<int?>("AttackerNumberQAnswer")
                        .HasColumnType("int")
                        .HasColumnName("attackerNumberQAnswer");

                    b.Property<bool?>("AttackerWon")
                        .HasColumnType("bit")
                        .HasColumnName("attackerWon");

                    b.Property<int>("NeutralRoundId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttackedTerritoryId");

                    b.HasIndex("NeutralRoundId");

                    b.ToTable("AttackingNeutralTerritory");
                });

            modelBuilder.Entity("GameService.Models.Borders", b =>
                {
                    b.Property<int>("ThisTerritory")
                        .HasColumnType("int");

                    b.Property<int>("NextToTerritory")
                        .HasColumnType("int");

                    b.HasKey("ThisTerritory", "NextToTerritory")
                        .HasName("pk_myConstraint");

                    b.HasIndex("NextToTerritory");

                    b.ToTable("Borders");
                });

            modelBuilder.Entity("GameService.Models.GameInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime")
                        .HasColumnName("end_time");

                    b.Property<int>("GameCreatorId")
                        .HasColumnType("int")
                        .HasColumnName("gameCreatorId");

                    b.Property<int>("GameRoundNumber")
                        .HasColumnType("int")
                        .HasColumnName("gameRoundNumber");

                    b.Property<string>("GameState")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("IN_LOBBY");

                    b.Property<string>("InvitationLink")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("invitationLink");

                    b.Property<int>("Mapid")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionTimerSeconds")
                        .HasColumnType("int")
                        .HasColumnName("questionTimerSeconds");

                    b.Property<int>("ResultId")
                        .HasColumnType("int")
                        .HasColumnName("resultId");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("Mapid");

                    b.HasIndex("ParticipantsId");

                    b.HasIndex("ResultId");

                    b.ToTable("GameInstance");
                });

            modelBuilder.Entity("GameService.Models.MapTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MapId")
                        .HasColumnType("int")
                        .HasColumnName("mapId");

                    b.Property<string>("TerritoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("territoryName");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("MapTerritory");
                });

            modelBuilder.Entity("GameService.Models.Maps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("GameService.Models.NeutralRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("NeutralRound");
                });

            modelBuilder.Entity("GameService.Models.ObjectTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameInstanceId")
                        .HasColumnType("int")
                        .HasColumnName("gameInstanceId");

                    b.Property<bool>("IsAttacked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isAttacked");

                    b.Property<bool>("IsCapital")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isCapital");

                    b.Property<int>("MapTerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("mapTerritoryId");

                    b.Property<int?>("TakenBy")
                        .HasColumnType("int")
                        .HasColumnName("takenBy");

                    b.Property<int>("TerritoryScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("territoryScore");

                    b.HasKey("Id");

                    b.HasIndex("GameInstanceId");

                    b.HasIndex("MapTerritoryId");

                    b.ToTable("ObjectTerritory");
                });

            modelBuilder.Entity("GameService.Models.Participants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("penguinAvatar.svg")
                        .HasColumnName("avatarName");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("gameId");

                    b.Property<bool>("IsBot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isBot");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int")
                        .HasColumnName("playerId");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("score");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("GameService.Models.PvpRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttackedTerritoryId")
                        .HasColumnType("int");

                    b.Property<int>("AttackerId")
                        .HasColumnType("int")
                        .HasColumnName("attackerId");

                    b.Property<int?>("DefenderId")
                        .HasColumnType("int")
                        .HasColumnName("defenderId");

                    b.Property<int>("NumberQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int")
                        .HasColumnName("winnerId");

                    b.HasKey("Id");

                    b.HasIndex("AttackedTerritoryId");

                    b.HasIndex("NumberQuestionId")
                        .IsUnique();

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("PvpRounds");
                });

            modelBuilder.Entity("GameService.Models.PvpRoundAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MChoiceQAnswerId")
                        .HasColumnType("int")
                        .HasColumnName("mChoiceQAnswerId");

                    b.Property<int?>("NumberQAnswer")
                        .HasColumnType("int")
                        .HasColumnName("numberQAnswer");

                    b.Property<int>("PvpRoundId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("PvpRoundId");

                    b.ToTable("PvpRoundAnswers");
                });

            modelBuilder.Entity("GameService.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Question")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("question");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.Property<int>("RoundsId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GameService.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttackStage")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("MULTIPLE_NEUTRAL");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<int>("GameInstanceId")
                        .HasColumnType("int")
                        .HasColumnName("gameInstanceId");

                    b.Property<int>("GameRoundNumber")
                        .HasColumnType("int")
                        .HasColumnName("gameRoundNumber");

                    b.Property<bool>("IsQuestionVotingOpen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isQuestionVotingOpen");

                    b.Property<bool>("IsTerritoryVotingOpen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isTerritoryVotingOpen");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("RoundStage")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("NOT_STARTED");

                    b.HasKey("Id");

                    b.HasIndex("GameInstanceId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("GameService.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExternalId")
                        .HasColumnType("int")
                        .HasColumnName("externalId");

                    b.Property<bool>("IsInGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isInGame");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameService.Models.Answers", b =>
                {
                    b.HasOne("GameService.Models.Questions", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__Answers__questio__5DCAEF64")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("GameService.Models.AttackingNeutralTerritory", b =>
                {
                    b.HasOne("GameService.Models.ObjectTerritory", "AttackedTerritory")
                        .WithMany("NeutralRoundsAttacks")
                        .HasForeignKey("AttackedTerritoryId")
                        .HasConstraintName("FK__attTer__neuAtt__8AJAWDSW");

                    b.HasOne("GameService.Models.NeutralRound", "NeutralRound")
                        .WithMany("TerritoryAttackers")
                        .HasForeignKey("NeutralRoundId")
                        .HasConstraintName("FK__NeuRound__terAtt__8AWDJXCS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttackedTerritory");

                    b.Navigation("NeutralRound");
                });

            modelBuilder.Entity("GameService.Models.Borders", b =>
                {
                    b.HasOne("GameService.Models.MapTerritory", "NextToTerritoryNavigation")
                        .WithMany("BordersNextToTerritoryNavigation")
                        .HasForeignKey("NextToTerritory")
                        .HasConstraintName("FK_Borders_MapTerritory1")
                        .IsRequired();

                    b.HasOne("GameService.Models.MapTerritory", "ThisTerritoryNavigation")
                        .WithMany("BordersThisTerritoryNavigation")
                        .HasForeignKey("ThisTerritory")
                        .HasConstraintName("FK_Borders_MapTerritory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextToTerritoryNavigation");

                    b.Navigation("ThisTerritoryNavigation");
                });

            modelBuilder.Entity("GameService.Models.GameInstance", b =>
                {
                    b.HasOne("GameService.Models.Maps", "Map")
                        .WithMany("GameInstance")
                        .HasForeignKey("Mapid")
                        .HasConstraintName("FK_GameInstance_Maps")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("GameService.Models.MapTerritory", b =>
                {
                    b.HasOne("GameService.Models.Maps", "Map")
                        .WithMany("MapTerritory")
                        .HasForeignKey("MapId")
                        .HasConstraintName("FK_MapTerritory_Maps")
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("GameService.Models.NeutralRound", b =>
                {
                    b.HasOne("GameService.Models.Round", "Round")
                        .WithOne("NeutralRound")
                        .HasForeignKey("GameService.Models.NeutralRound", "RoundId")
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("GameService.Models.ObjectTerritory", b =>
                {
                    b.HasOne("GameService.Models.GameInstance", "GameInstance")
                        .WithMany("ObjectTerritory")
                        .HasForeignKey("GameInstanceId")
                        .HasConstraintName("FK__ObjectTer__gameIn__5AEE82B9")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.Models.MapTerritory", "MapTerritory")
                        .WithMany("ObjectTerritory")
                        .HasForeignKey("MapTerritoryId")
                        .HasConstraintName("FK__ObjectTer__mapTe__59FA5E80")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameInstance");

                    b.Navigation("MapTerritory");
                });

            modelBuilder.Entity("GameService.Models.Participants", b =>
                {
                    b.HasOne("GameService.Models.GameInstance", "Game")
                        .WithMany("Participants")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK__Participa__gameI__5812160E")
                        .IsRequired();

                    b.HasOne("GameService.Models.Users", "Player")
                        .WithMany("Participants")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Participa__playe__571DF1D5")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GameService.Models.PvpRound", b =>
                {
                    b.HasOne("GameService.Models.ObjectTerritory", "AttackedTerritory")
                        .WithMany("PvpRounds")
                        .HasForeignKey("AttackedTerritoryId")
                        .HasConstraintName("FK__attTer__pvpRou__123JKAWD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.Models.Questions", "NumberQuestion")
                        .WithOne("PvpRoundNum")
                        .HasForeignKey("GameService.Models.PvpRound", "NumberQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.Models.Round", "Round")
                        .WithOne("PvpRound")
                        .HasForeignKey("GameService.Models.PvpRound", "RoundId")
                        .IsRequired();

                    b.Navigation("AttackedTerritory");

                    b.Navigation("NumberQuestion");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("GameService.Models.PvpRoundAnswers", b =>
                {
                    b.HasOne("GameService.Models.PvpRound", "PvpRound")
                        .WithMany("PvpRoundAnswers")
                        .HasForeignKey("PvpRoundId")
                        .HasConstraintName("FK__pvpRou__pvpRouAns__A8AWDJBNS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PvpRound");
                });

            modelBuilder.Entity("GameService.Models.Questions", b =>
                {
                    b.HasOne("GameService.Models.Round", "Round")
                        .WithOne("Question")
                        .HasForeignKey("GameService.Models.Questions", "RoundId")
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("GameService.Models.Round", b =>
                {
                    b.HasOne("GameService.Models.GameInstance", "GameInstance")
                        .WithMany("Rounds")
                        .HasForeignKey("GameInstanceId")
                        .HasConstraintName("FK__Round__gameI__5CD6CB2B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameInstance");
                });

            modelBuilder.Entity("GameService.Models.GameInstance", b =>
                {
                    b.Navigation("ObjectTerritory");

                    b.Navigation("Participants");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("GameService.Models.MapTerritory", b =>
                {
                    b.Navigation("BordersNextToTerritoryNavigation");

                    b.Navigation("BordersThisTerritoryNavigation");

                    b.Navigation("ObjectTerritory");
                });

            modelBuilder.Entity("GameService.Models.Maps", b =>
                {
                    b.Navigation("GameInstance");

                    b.Navigation("MapTerritory");
                });

            modelBuilder.Entity("GameService.Models.NeutralRound", b =>
                {
                    b.Navigation("TerritoryAttackers");
                });

            modelBuilder.Entity("GameService.Models.ObjectTerritory", b =>
                {
                    b.Navigation("NeutralRoundsAttacks");

                    b.Navigation("PvpRounds");
                });

            modelBuilder.Entity("GameService.Models.PvpRound", b =>
                {
                    b.Navigation("PvpRoundAnswers");
                });

            modelBuilder.Entity("GameService.Models.Questions", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("PvpRoundNum");
                });

            modelBuilder.Entity("GameService.Models.Round", b =>
                {
                    b.Navigation("NeutralRound");

                    b.Navigation("PvpRound");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("GameService.Models.Users", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
