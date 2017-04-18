namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCreditNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreditCardNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreditCardNumber");
        }
    }
}
