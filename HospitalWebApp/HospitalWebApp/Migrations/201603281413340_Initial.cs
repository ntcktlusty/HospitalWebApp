namespace HospitalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ValidTo = c.DateTime(nullable: false),
                        ValidSince = c.DateTime(nullable: false),
                        MealTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MealTypes", t => t.MealTypeID, cascadeDelete: true)
                .Index(t => t.MealTypeID);
            
            CreateTable(
                "dbo.MealTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        PatientID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meals", t => t.MealID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        DueTo = c.DateTime(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Orders", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Orders", "MealID", "dbo.Meals");
            DropForeignKey("dbo.Meals", "MealTypeID", "dbo.MealTypes");
            DropIndex("dbo.Stations", new[] { "PatientID" });
            DropIndex("dbo.Orders", new[] { "MealID" });
            DropIndex("dbo.Orders", new[] { "PatientID" });
            DropIndex("dbo.Meals", new[] { "MealTypeID" });
            DropTable("dbo.Stations");
            DropTable("dbo.Patients");
            DropTable("dbo.Orders");
            DropTable("dbo.MealTypes");
            DropTable("dbo.Meals");
        }
    }
}
