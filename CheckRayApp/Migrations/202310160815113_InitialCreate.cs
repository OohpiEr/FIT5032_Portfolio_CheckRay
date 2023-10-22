namespace CheckRayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Doctor_Id = c.Int(),
                        Facility_FacilityId = c.Int(),
                        Patient_Id = c.Int(),
                        Review_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Doctor_Id)
                .ForeignKey("dbo.Facilities", t => t.Facility_FacilityId)
                .ForeignKey("dbo.Users", t => t.Patient_Id)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Facility_FacilityId)
                .Index(t => t.Patient_Id)
                .Index(t => t.Review_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        FacilityId = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(),
                        FacilityAddress = c.String(),
                    })
                .PrimaryKey(t => t.FacilityId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Bookings", "Patient_Id", "dbo.Users");
            DropForeignKey("dbo.Bookings", "Facility_FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Bookings", "Doctor_Id", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Bookings", new[] { "Review_Id" });
            DropIndex("dbo.Bookings", new[] { "Patient_Id" });
            DropIndex("dbo.Bookings", new[] { "Facility_FacilityId" });
            DropIndex("dbo.Bookings", new[] { "Doctor_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Facilities");
            DropTable("dbo.Users");
            DropTable("dbo.Bookings");
        }
    }
}
