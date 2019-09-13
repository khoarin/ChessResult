namespace Nexcel.ChessResult.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChessResultv11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompetitionTypes", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentRounds", "TournamentGroup_Id", "dbo.TournamentGroups");
            DropIndex("dbo.CompetitionTypes", new[] { "Tournament_Id" });
            DropIndex("dbo.TournamentRounds", "IX_TournamentGroup_RoundNo");
            DropIndex("dbo.TournamentRounds", new[] { "TournamentGroup_Id" });
            RenameColumn(table: "dbo.TournamentRounds", name: "TournamentGroup_Id", newName: "TournamentGroupId");
            AlterColumn("dbo.TournamentRounds", "TournamentGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.TournamentRounds", new[] { "TournamentGroupId", "No" }, unique: true, name: "IX_TournamentGroup_RoundNo");
            AddForeignKey("dbo.TournamentRounds", "TournamentGroupId", "dbo.TournamentGroups", "Id", cascadeDelete: true);
            DropColumn("dbo.CompetitionTypes", "Tournament_Id");
            DropColumn("dbo.TournamentRounds", "TouramentGroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TournamentRounds", "TouramentGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.CompetitionTypes", "Tournament_Id", c => c.Int());
            DropForeignKey("dbo.TournamentRounds", "TournamentGroupId", "dbo.TournamentGroups");
            DropIndex("dbo.TournamentRounds", "IX_TournamentGroup_RoundNo");
            AlterColumn("dbo.TournamentRounds", "TournamentGroupId", c => c.Int());
            RenameColumn(table: "dbo.TournamentRounds", name: "TournamentGroupId", newName: "TournamentGroup_Id");
            CreateIndex("dbo.TournamentRounds", "TournamentGroup_Id");
            CreateIndex("dbo.TournamentRounds", new[] { "TouramentGroupId", "No" }, unique: true, name: "IX_TournamentGroup_RoundNo");
            CreateIndex("dbo.CompetitionTypes", "Tournament_Id");
            AddForeignKey("dbo.TournamentRounds", "TournamentGroup_Id", "dbo.TournamentGroups", "Id");
            AddForeignKey("dbo.CompetitionTypes", "Tournament_Id", "dbo.Tournaments", "Id");
        }
    }
}
