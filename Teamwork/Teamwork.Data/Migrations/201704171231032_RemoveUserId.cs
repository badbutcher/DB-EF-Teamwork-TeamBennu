namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "UserId", c => c.Int());
        }
    }
}
