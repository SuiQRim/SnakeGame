namespace SnakeGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Profils", newName: "Players");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Players", newName: "Profils");
        }
    }
}
