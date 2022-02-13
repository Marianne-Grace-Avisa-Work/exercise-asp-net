namespace RegisterLoginLogout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.UserAccounts", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "UserName", c => c.String(nullable: false));
        }
    }
}
