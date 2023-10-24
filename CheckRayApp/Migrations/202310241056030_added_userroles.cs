namespace CheckRayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_userroles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserRoles_DataGroupField", c => c.String());
            AddColumn("dbo.Users", "UserRoles_DataTextField", c => c.String());
            AddColumn("dbo.Users", "UserRoles_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserRoles_DataValueField");
            DropColumn("dbo.Users", "UserRoles_DataTextField");
            DropColumn("dbo.Users", "UserRoles_DataGroupField");
        }
    }
}
