﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_core_backend.Context;

namespace net_core_backend.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20211021215729_CapitalScoreProperties")]
    partial class CapitalScoreProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("net_core_backend.Models.Answers", b =>
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

            modelBuilder.Entity("net_core_backend.Models.Borders", b =>
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

            modelBuilder.Entity("net_core_backend.Models.GameInstance", b =>
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

            modelBuilder.Entity("net_core_backend.Models.MapTerritory", b =>
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

            modelBuilder.Entity("net_core_backend.Models.Maps", b =>
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

            modelBuilder.Entity("net_core_backend.Models.ObjectTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttackedBy")
                        .HasColumnType("int")
                        .HasColumnName("attackedBy");

                    b.Property<int>("GameInstanceId")
                        .HasColumnType("int")
                        .HasColumnName("gameInstanceId");

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

            modelBuilder.Entity("net_core_backend.Models.Participants", b =>
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

            modelBuilder.Entity("net_core_backend.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNumberQuestion")
                        .HasColumnType("bit")
                        .HasColumnName("isNumberQuestion");

                    b.Property<string>("Question")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("question");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("net_core_backend.Models.RefreshToken", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId", "Id");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("net_core_backend.Models.RoundQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("questionId");

                    b.Property<int>("RoundId")
                        .HasColumnType("int")
                        .HasColumnName("roundId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("RoundId");

                    b.ToTable("RoundQuestion");
                });

            modelBuilder.Entity("net_core_backend.Models.Rounds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttackerId")
                        .HasColumnType("int")
                        .HasColumnName("attackerId");

                    b.Property<int?>("DefenderId")
                        .HasColumnType("int")
                        .HasColumnName("defenderId");

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

                    b.Property<bool>("IsLastUntakenTerritories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isLastUntakenTerritories");

                    b.Property<string>("RoundStage")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("NOT_STARTED");

                    b.Property<int?>("RoundWinnerId")
                        .HasColumnType("int")
                        .HasColumnName("roundWinnerId");

                    b.HasKey("Id");

                    b.HasIndex("GameInstanceId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("net_core_backend.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit")
                        .HasColumnName("isBanned");

                    b.Property<bool>("IsInGame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isInGame");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit")
                        .HasColumnName("isOnline");

                    b.Property<bool>("Provider")
                        .HasColumnType("bit")
                        .HasColumnName("provider");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("user")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("net_core_backend.Models.Answers", b =>
                {
                    b.HasOne("net_core_backend.Models.Questions", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__Answers__questio__5DCAEF64")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("net_core_backend.Models.Borders", b =>
                {
                    b.HasOne("net_core_backend.Models.MapTerritory", "NextToTerritoryNavigation")
                        .WithMany("BordersNextToTerritoryNavigation")
                        .HasForeignKey("NextToTerritory")
                        .HasConstraintName("FK_Borders_MapTerritory1")
                        .IsRequired();

                    b.HasOne("net_core_backend.Models.MapTerritory", "ThisTerritoryNavigation")
                        .WithMany("BordersThisTerritoryNavigation")
                        .HasForeignKey("ThisTerritory")
                        .HasConstraintName("FK_Borders_MapTerritory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextToTerritoryNavigation");

                    b.Navigation("ThisTerritoryNavigation");
                });

            modelBuilder.Entity("net_core_backend.Models.GameInstance", b =>
                {
                    b.HasOne("net_core_backend.Models.Maps", "Map")
                        .WithMany("GameInstance")
                        .HasForeignKey("Mapid")
                        .HasConstraintName("FK_GameInstance_Maps")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("net_core_backend.Models.MapTerritory", b =>
                {
                    b.HasOne("net_core_backend.Models.Maps", "Map")
                        .WithMany("MapTerritory")
                        .HasForeignKey("MapId")
                        .HasConstraintName("FK_MapTerritory_Maps")
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("net_core_backend.Models.ObjectTerritory", b =>
                {
                    b.HasOne("net_core_backend.Models.GameInstance", "GameInstance")
                        .WithMany("ObjectTerritory")
                        .HasForeignKey("GameInstanceId")
                        .HasConstraintName("FK__ObjectTer__gameIn__5AEE82B9")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("net_core_backend.Models.MapTerritory", "MapTerritory")
                        .WithMany("ObjectTerritory")
                        .HasForeignKey("MapTerritoryId")
                        .HasConstraintName("FK__ObjectTer__mapTe__59FA5E80")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameInstance");

                    b.Navigation("MapTerritory");
                });

            modelBuilder.Entity("net_core_backend.Models.Participants", b =>
                {
                    b.HasOne("net_core_backend.Models.GameInstance", "Game")
                        .WithMany("Participants")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK__Participa__gameI__5812160E")
                        .IsRequired();

                    b.HasOne("net_core_backend.Models.Users", "Player")
                        .WithMany("Participants")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Participa__playe__571DF1D5")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("net_core_backend.Models.RefreshToken", b =>
                {
                    b.HasOne("net_core_backend.Models.Users", "Users")
                        .WithMany("RefreshToken")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("net_core_backend.Models.RoundQuestion", b =>
                {
                    b.HasOne("net_core_backend.Models.Questions", "Question")
                        .WithMany("RoundQuestion")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__RoundQues__quest__5FB337D6")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("net_core_backend.Models.Rounds", "Round")
                        .WithMany("RoundQuestion")
                        .HasForeignKey("RoundId")
                        .HasConstraintName("FK__RoundQues__round__5EBF139D")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("net_core_backend.Models.Rounds", b =>
                {
                    b.HasOne("net_core_backend.Models.GameInstance", "GameInstance")
                        .WithMany("Rounds")
                        .HasForeignKey("GameInstanceId")
                        .HasConstraintName("FK__RoundsHis__gameI__5CD6CB2B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameInstance");
                });

            modelBuilder.Entity("net_core_backend.Models.GameInstance", b =>
                {
                    b.Navigation("ObjectTerritory");

                    b.Navigation("Participants");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("net_core_backend.Models.MapTerritory", b =>
                {
                    b.Navigation("BordersNextToTerritoryNavigation");

                    b.Navigation("BordersThisTerritoryNavigation");

                    b.Navigation("ObjectTerritory");
                });

            modelBuilder.Entity("net_core_backend.Models.Maps", b =>
                {
                    b.Navigation("GameInstance");

                    b.Navigation("MapTerritory");
                });

            modelBuilder.Entity("net_core_backend.Models.Questions", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("RoundQuestion");
                });

            modelBuilder.Entity("net_core_backend.Models.Rounds", b =>
                {
                    b.Navigation("RoundQuestion");
                });

            modelBuilder.Entity("net_core_backend.Models.Users", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
