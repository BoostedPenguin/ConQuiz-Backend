﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_core_backend.Models;

namespace net_core_backend.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20210926164518_refreshtoken-fix")]
    partial class refreshtokenfix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("net_core_backend.Models.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnName("answer")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool?>("Correct")
                        .HasColumnName("correct")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnName("questionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnName("end_time")
                        .HasColumnType("datetime");

                    b.Property<bool?>("InProgress")
                        .HasColumnName("inProgress")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionTimerSeconds")
                        .HasColumnName("questionTimerSeconds")
                        .HasColumnType("int");

                    b.Property<int?>("ResultId")
                        .HasColumnName("resultId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnName("start_time")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("GameInstance");
                });

            modelBuilder.Entity("net_core_backend.Models.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("GameResult");
                });

            modelBuilder.Entity("net_core_backend.Models.MapObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameInstanceId")
                        .HasColumnName("gameInstanceId")
                        .HasColumnType("int");

                    b.Property<int?>("Mapid")
                        .HasColumnName("mapid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MapObject");
                });

            modelBuilder.Entity("net_core_backend.Models.MapTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MapId")
                        .HasColumnName("mapId")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryName")
                        .IsRequired()
                        .HasColumnName("territoryName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("MapTerritory");
                });

            modelBuilder.Entity("net_core_backend.Models.Maps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("net_core_backend.Models.ObjectTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MapObjectId")
                        .HasColumnName("mapObjectId")
                        .HasColumnType("int");

                    b.Property<int?>("MapTerritoryId")
                        .HasColumnName("mapTerritoryId")
                        .HasColumnType("int");

                    b.Property<int?>("TakenBy")
                        .HasColumnName("takenBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ObjectTerritory");
                });

            modelBuilder.Entity("net_core_backend.Models.Participants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId")
                        .HasColumnName("gameId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnName("playerId")
                        .HasColumnType("int");

                    b.Property<int?>("Score")
                        .HasColumnName("score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("net_core_backend.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsNumberQuestion")
                        .HasColumnName("isNumberQuestion")
                        .HasColumnType("bit");

                    b.Property<string>("Question")
                        .HasColumnName("question")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

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
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("QuestionId")
                        .HasColumnName("questionId")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnName("roundId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoundQuestion");
                });

            modelBuilder.Entity("net_core_backend.Models.Rounds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TotalRounds")
                        .HasColumnName("totalRounds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("net_core_backend.Models.RoundsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttackerId")
                        .HasColumnName("attackerId")
                        .HasColumnType("int");

                    b.Property<int?>("DefenderId")
                        .HasColumnName("defenderId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("GameInstanceId")
                        .HasColumnName("gameInstanceId")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnName("roundID")
                        .HasColumnType("int");

                    b.Property<int?>("RoundWinnerId")
                        .HasColumnName("roundWinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoundsHistory");
                });

            modelBuilder.Entity("net_core_backend.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsAdmin")
                        .HasColumnName("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanned")
                        .HasColumnName("isBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnName("isOnline")
                        .HasColumnType("bit");

                    b.Property<bool>("Provider")
                        .HasColumnName("provider")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
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
                });

            modelBuilder.Entity("net_core_backend.Models.MapTerritory", b =>
                {
                    b.HasOne("net_core_backend.Models.Maps", "Map")
                        .WithMany("MapTerritory")
                        .HasForeignKey("MapId")
                        .HasConstraintName("FK_MapTerritory_Maps")
                        .IsRequired();
                });

            modelBuilder.Entity("net_core_backend.Models.RefreshToken", b =>
                {
                    b.HasOne("net_core_backend.Models.Users", "Users")
                        .WithMany("RefreshToken")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
