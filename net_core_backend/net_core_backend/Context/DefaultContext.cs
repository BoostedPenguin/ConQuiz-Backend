﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace net_core_backend.Models
{
    public partial class DefaultContext : DbContext
    {
        public DefaultContext()
        {
        }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Borders> Borders { get; set; }
        public virtual DbSet<GameInstance> GameInstance { get; set; }
        public virtual DbSet<GameResult> GameResult { get; set; }
        public virtual DbSet<MapTerritory> MapTerritory { get; set; }
        public virtual DbSet<Maps> Maps { get; set; }
        public virtual DbSet<ObjectTerritory> ObjectTerritory { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<RoundQuestion> RoundQuestion { get; set; }
        public virtual DbSet<Rounds> Rounds { get; set; }
        public virtual DbSet<RoundsHistory> RoundsHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasMaxLength(255);

                entity.Property(e => e.Correct).HasColumnName("correct");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");
            });

            modelBuilder.Entity<Borders>(entity =>
            {
                entity.HasKey(e => new { e.ThisTerritory, e.NextToTerritory })
                    .HasName("pk_myConstraint");

                entity.HasIndex(e => e.NextToTerritory);

                entity.HasOne(d => d.NextToTerritoryNavigation)
                    .WithMany(p => p.BordersNextToTerritoryNavigation)
                    .HasForeignKey(d => d.NextToTerritory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Borders_MapTerritory1");

                entity.HasOne(d => d.ThisTerritoryNavigation)
                    .WithMany(p => p.BordersThisTerritoryNavigation)
                    .HasForeignKey(d => d.ThisTerritory)
                    .HasConstraintName("FK_Borders_MapTerritory");
            });

            modelBuilder.Entity<GameInstance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.InProgress).HasColumnName("inProgress");

                entity.Property(e => e.QuestionTimerSeconds).HasColumnName("questionTimerSeconds");

                entity.Property(e => e.ResultId).HasColumnName("resultId");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GameResult>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MapTerritory>(entity =>
            {
                entity.HasIndex(e => e.MapId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MapId).HasColumnName("mapId");

                entity.Property(e => e.TerritoryName)
                    .IsRequired()
                    .HasColumnName("territoryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Map)
                    .WithMany(p => p.MapTerritory)
                    .HasForeignKey(d => d.MapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MapTerritory_Maps");
            });

            modelBuilder.Entity<Maps>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<ObjectTerritory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MapObjectId).HasColumnName("mapObjectId");

                entity.Property(e => e.MapTerritoryId).HasColumnName("mapTerritoryId");

                entity.Property(e => e.TakenBy).HasColumnName("takenBy");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.Score).HasColumnName("score");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsNumberQuestion).HasColumnName("isNumberQuestion");

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => new { e.UsersId, e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.UsersId);
            });

            modelBuilder.Entity<RoundQuestion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.Property(e => e.RoundId).HasColumnName("roundId");
            });

            modelBuilder.Entity<Rounds>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TotalRounds).HasColumnName("totalRounds");
            });

            modelBuilder.Entity<RoundsHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttackerId).HasColumnName("attackerId");

                entity.Property(e => e.DefenderId).HasColumnName("defenderId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.GameInstanceId).HasColumnName("gameInstanceId");

                entity.Property(e => e.RoundId).HasColumnName("roundID");

                entity.Property(e => e.RoundWinnerId).HasColumnName("roundWinnerId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.IsBanned).HasColumnName("isBanned");

                entity.Property(e => e.IsOnline).HasColumnName("isOnline");

                entity.Property(e => e.Provider).HasColumnName("provider");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
