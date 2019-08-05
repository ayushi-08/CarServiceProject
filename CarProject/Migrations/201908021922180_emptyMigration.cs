namespace CarProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropColumn("dbo.Cars", "userId");
        }
        
        public override void Down()
        {
        }
    }
}
