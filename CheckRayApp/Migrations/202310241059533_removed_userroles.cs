namespace CheckRayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_userroles : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserRoles_DataGroupField");
            DropColumn("dbo.Users", "UserRoles_DataTextField");
            DropColumn("dbo.Users", "UserRoles_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserRoles_DataValueField", c => c.String());
            AddColumn("dbo.Users", "UserRoles_DataTextField", c => c.String());
            AddColumn("dbo.Users", "UserRoles_DataGroupField", c => c.String());
        }
    }
}
