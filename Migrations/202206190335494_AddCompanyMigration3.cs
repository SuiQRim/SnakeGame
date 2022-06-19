namespace SnakeGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameResults", "PlayerNickName", c => c.String());
            DropColumn("dbo.GameResults", "ComputerId");
            DropColumn("dbo.Players", "ComputerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "ComputerId", c => c.String());
            AddColumn("dbo.GameResults", "ComputerId", c => c.String());
            DropColumn("dbo.GameResults", "PlayerNickName");
        }
    }
}
