namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boards", "Availability_id", "dbo.Board_Availbality");
            DropForeignKey("dbo.Boards", "Board_City_Id", "dbo.Board_city");
            DropForeignKey("dbo.Boards", "Board_Location_Id", "dbo.Board_Location");
            DropForeignKey("dbo.Boards", "Board_Medium_Id", "dbo.Board_medium");
            DropIndex("dbo.Boards", new[] { "Board_Medium_Id" });
            DropIndex("dbo.Boards", new[] { "Board_City_Id" });
            DropIndex("dbo.Boards", new[] { "Board_Location_Id" });
            DropIndex("dbo.Boards", new[] { "Availability_id" });
            DropColumn("dbo.Boards", "Board_Medium_Id");
            DropColumn("dbo.Boards", "Board_City_Id");
            DropColumn("dbo.Boards", "Board_Location_Id");
            DropColumn("dbo.Boards", "Availability_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boards", "Availability_id", c => c.Int(nullable: false));
            AddColumn("dbo.Boards", "Board_Location_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Boards", "Board_City_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Boards", "Board_Medium_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Boards", "Availability_id");
            CreateIndex("dbo.Boards", "Board_Location_Id");
            CreateIndex("dbo.Boards", "Board_City_Id");
            CreateIndex("dbo.Boards", "Board_Medium_Id");
            AddForeignKey("dbo.Boards", "Board_Medium_Id", "dbo.Board_medium", "Board_Medium_Id", cascadeDelete: true);
            AddForeignKey("dbo.Boards", "Board_Location_Id", "dbo.Board_Location", "Board_Location_Id", cascadeDelete: true);
            AddForeignKey("dbo.Boards", "Board_City_Id", "dbo.Board_city", "Board_City_Id", cascadeDelete: true);
            AddForeignKey("dbo.Boards", "Availability_id", "dbo.Board_Availbality", "Availability_id", cascadeDelete: true);
        }
    }
}
