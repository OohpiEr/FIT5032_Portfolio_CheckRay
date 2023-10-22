namespace CheckRayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_UserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserId");
        }
    }
}
