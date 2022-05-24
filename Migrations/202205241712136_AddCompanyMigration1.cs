namespace SnakeGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameResults", "ComputerId", c => c.String());
            DropColumn("dbo.Profils", "BestResultsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profils", "BestResultsId", c => c.Int(nullable: false));
            DropColumn("dbo.GameResults", "ComputerId");
        }
    }
}
