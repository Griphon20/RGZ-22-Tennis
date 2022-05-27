using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tennis
{
    public partial class tennisContext : DbContext
    {
        public tennisContext()
        {
        }

        public tennisContext(DbContextOptions<tennisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<PlayerStat> PlayerStats { get; set; } = null!;
        public virtual DbSet<Quarter> Quarters { get; set; } = null!;
        public virtual DbSet<Season> Seasons { get; set; } = null!;
        public virtual DbSet<Tourney> Tourneys { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Админ\\Desktop\\вп\\Гриша\\tennis.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Player1).HasColumnName("player1");

                entity.Property(e => e.Player2).HasColumnName("player2");

                entity.Property(e => e.Quarter).HasColumnName("quarter");

                entity.Property(e => e.Winner).HasColumnName("winner");

                entity.HasOne(d => d.Player1Navigation)
                    .WithMany(p => p.MatchPlayer1Navigations)
                    .HasForeignKey(d => d.Player1);

                entity.HasOne(d => d.Player2Navigation)
                    .WithMany(p => p.MatchPlayer2Navigations)
                    .HasForeignKey(d => d.Player2);

                entity.HasOne(d => d.QuarterNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.Quarter);

                entity.HasOne(d => d.WinnerNavigation)
                    .WithMany(p => p.MatchWinnerNavigations)
                    .HasForeignKey(d => d.Winner);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasColumnType("STRING")
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .HasColumnType("STRING")
                    .HasColumnName("name");

                entity.Property(e => e.Rank).HasColumnName("rank");
            });

            modelBuilder.Entity<PlayerStat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aces).HasColumnName("aces");

                entity.Property(e => e.DoubleFaults).HasColumnName("doubleFaults");

                entity.Property(e => e.Match).HasColumnName("match");

                entity.Property(e => e.Player).HasColumnName("player");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.MatchNavigation)
                    .WithMany(p => p.PlayerStats)
                    .HasForeignKey(d => d.Match);

                entity.HasOne(d => d.PlayerNavigation)
                    .WithMany(p => p.PlayerStats)
                    .HasForeignKey(d => d.Player);
            });

            modelBuilder.Entity<Quarter>(entity =>
            {
                entity.ToTable("Quarter");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.QtrType).HasColumnName("qtrType");

                entity.Property(e => e.Tourney).HasColumnName("tourney");

                entity.HasOne(d => d.TourneyNavigation)
                    .WithMany(p => p.Quarters)
                    .HasForeignKey(d => d.Tourney);
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("Season");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.StartDate).HasColumnName("startDate");
            });

            modelBuilder.Entity<Tourney>(entity =>
            {
                entity.ToTable("Tourney");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.Property(e => e.Season).HasColumnName("season");

                entity.HasOne(d => d.SeasonNavigation)
                    .WithMany(p => p.Tourneys)
                    .HasForeignKey(d => d.Season);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
