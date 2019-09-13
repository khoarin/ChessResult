using Nexcel.ChessResult.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Migration
{
    public class ChessReusltMigrationDbContext : DbContext 
    {
        public ChessReusltMigrationDbContext(): base($"Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChessReusltMigrationDbContext, Migrations.Configuration>());
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<Federation> Ferderations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<PlayerRoundResult> PlayerRoundResults { get; set; }
        public DbSet<RoundPairing> RoundPairings { get; set; }
        public DbSet<TournamentGroup> TournamentGroups { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentGroupPlayer> TournamentGroupPlayers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoundPairing>()
                .HasRequired(p => p.Player1)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RoundPairing>()
                .HasRequired(p => p.Player2)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Organizer>()
                .HasRequired(e => e.Federation)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
