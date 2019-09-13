namespace Nexcel.ChessResult.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChessResultv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FederationId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Federations", t => t.FederationId, cascadeDelete: true)
                .Index(t => t.FederationId);
            
            CreateTable(
                "dbo.Federations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 3),
                        FullName = c.String(nullable: false, maxLength: 256),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClubId = c.Int(nullable: false),
                        FideId = c.Int(),
                        Name = c.String(maxLength: 256),
                        Rating = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clubs", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.TournamentGroupPlayers",
                c => new
                    {
                        TournamentGroupId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        StartRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TournamentGroupId, t.PlayerId })
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.TournamentGroups", t => t.TournamentGroupId, cascadeDelete: true)
                .Index(t => t.TournamentGroupId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.TournamentGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        CompetitionTypeId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompetitionTypes", t => t.CompetitionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => new { t.TournamentId, t.CompetitionTypeId, t.Name }, unique: true, name: "IX_Tournament_CompetitonType");
            
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Tournament_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_Id)
                .Index(t => t.Tournament_Id);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizerId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        TournamentDirector = c.String(maxLength: 256),
                        ChiefArbiter = c.String(maxLength: 256),
                        Location = c.String(),
                        RatingCaculation = c.String(),
                        FromDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ToDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FederationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Federations", t => t.FederationId)
                .Index(t => t.FederationId);
            
            CreateTable(
                "dbo.PlayerRoundResults",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        RoundPairingId = c.Int(nullable: false),
                        Point = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.RoundPairingId })
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.RoundPairings", t => t.RoundPairingId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.RoundPairingId);
            
            CreateTable(
                "dbo.RoundPairings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TouramentRoundId = c.Int(nullable: false),
                        Player1Id = c.Int(nullable: false),
                        Player2Id = c.Int(nullable: false),
                        BlackPlayerId = c.Int(),
                        RoundResult = c.Int(),
                        Score = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player1Id)
                .ForeignKey("dbo.Players", t => t.Player2Id)
                .ForeignKey("dbo.TournamentRounds", t => t.TouramentRoundId, cascadeDelete: true)
                .Index(t => new { t.TouramentRoundId, t.Player1Id, t.Player2Id }, unique: true, name: "IX_TournamentRound_Player");
            
            CreateTable(
                "dbo.TournamentRounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TouramentGroupId = c.Int(nullable: false),
                        No = c.Int(nullable: false),
                        IsLastRound = c.Boolean(nullable: false),
                        TournamentGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TournamentGroups", t => t.TournamentGroup_Id)
                .Index(t => new { t.TouramentGroupId, t.No }, unique: true, name: "IX_TournamentGroup_RoundNo")
                .Index(t => t.TournamentGroup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerRoundResults", "RoundPairingId", "dbo.RoundPairings");
            DropForeignKey("dbo.TournamentRounds", "TournamentGroup_Id", "dbo.TournamentGroups");
            DropForeignKey("dbo.RoundPairings", "TouramentRoundId", "dbo.TournamentRounds");
            DropForeignKey("dbo.RoundPairings", "Player2Id", "dbo.Players");
            DropForeignKey("dbo.RoundPairings", "Player1Id", "dbo.Players");
            DropForeignKey("dbo.PlayerRoundResults", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.TournamentGroupPlayers", "TournamentGroupId", "dbo.TournamentGroups");
            DropForeignKey("dbo.TournamentGroups", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.CompetitionTypes", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.Tournaments", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.Organizers", "FederationId", "dbo.Federations");
            DropForeignKey("dbo.TournamentGroups", "CompetitionTypeId", "dbo.CompetitionTypes");
            DropForeignKey("dbo.TournamentGroupPlayers", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Clubs", "FederationId", "dbo.Federations");
            DropIndex("dbo.TournamentRounds", new[] { "TournamentGroup_Id" });
            DropIndex("dbo.TournamentRounds", "IX_TournamentGroup_RoundNo");
            DropIndex("dbo.RoundPairings", "IX_TournamentRound_Player");
            DropIndex("dbo.PlayerRoundResults", new[] { "RoundPairingId" });
            DropIndex("dbo.PlayerRoundResults", new[] { "PlayerId" });
            DropIndex("dbo.Organizers", new[] { "FederationId" });
            DropIndex("dbo.Tournaments", new[] { "OrganizerId" });
            DropIndex("dbo.CompetitionTypes", new[] { "Tournament_Id" });
            DropIndex("dbo.TournamentGroups", "IX_Tournament_CompetitonType");
            DropIndex("dbo.TournamentGroupPlayers", new[] { "PlayerId" });
            DropIndex("dbo.TournamentGroupPlayers", new[] { "TournamentGroupId" });
            DropIndex("dbo.Players", new[] { "ClubId" });
            DropIndex("dbo.Clubs", new[] { "FederationId" });
            DropTable("dbo.TournamentRounds");
            DropTable("dbo.RoundPairings");
            DropTable("dbo.PlayerRoundResults");
            DropTable("dbo.Organizers");
            DropTable("dbo.Tournaments");
            DropTable("dbo.CompetitionTypes");
            DropTable("dbo.TournamentGroups");
            DropTable("dbo.TournamentGroupPlayers");
            DropTable("dbo.Players");
            DropTable("dbo.Federations");
            DropTable("dbo.Clubs");
        }
    }
}
