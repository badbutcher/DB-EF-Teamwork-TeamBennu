namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameHasManyOwners : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "UserId", "dbo.Users");
            DropIndex("dbo.Games", new[] { "UserId" });
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Game_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.Users");
            DropIndex("dbo.UserGames", new[] { "Game_Id" });
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropTable("dbo.UserGames");
            CreateIndex("dbo.Games", "UserId");
            AddForeignKey("dbo.Games", "UserId", "dbo.Users", "Id");
        }
    }
}
