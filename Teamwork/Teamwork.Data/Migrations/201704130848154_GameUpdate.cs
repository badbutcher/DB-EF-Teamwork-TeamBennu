namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Price");
        }
    }
}
