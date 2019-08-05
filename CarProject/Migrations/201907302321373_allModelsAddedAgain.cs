namespace CarProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allModelsAddedAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VIN = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Style = c.String(),
                        Year = c.Int(nullable: false),
                        Miles = c.Double(nullable: false),
                        Color = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miles = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Details = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        CarId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Services", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "ServiceTypeId" });
            DropIndex("dbo.Services", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
            DropTable("dbo.Cars");
        }
    }
}
