namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Broard_Id = c.Int(nullable: false, identity: true),
                        Broard_Site_code = c.String(nullable: false),
                        Broard_Traffic_from = c.String(nullable: false),
                        Broard_Traffic_to = c.String(nullable: false),
                        Broard_Width = c.Int(nullable: false),
                        Broard_Height = c.Int(nullable: false),
                        Broard_Medium = c.String(nullable: false),
                        Board_Location_Id = c.Int(nullable: false),
                        Availability_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Broard_Id)
                .ForeignKey("dbo.Board_Availbality", t => t.Availability_id, cascadeDelete: true)
                .ForeignKey("dbo.Board_Location", t => t.Board_Location_Id, cascadeDelete: true)
                .Index(t => t.Board_Location_Id)
                .Index(t => t.Availability_id);
            
            CreateTable(
                "dbo.Board_Availbality",
                c => new
                    {
                        Availability_id = c.Int(nullable: false, identity: true),
                        Availability = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Availability_id);
            
            CreateTable(
                "dbo.Board_Location",
                c => new
                    {
                        Board_Location_Id = c.Int(nullable: false, identity: true),
                        Board_location = c.String(nullable: false),
                        Board_City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Board_Location_Id);
            
            CreateTable(
                "dbo.sliders",
                c => new
                    {
                        Slider_Id = c.Int(nullable: false, identity: true),
                        Slider_Title = c.String(nullable: false),
                        Slider_Image = c.String(nullable: false),
                        Slider_Status = c.Boolean(nullable: false),
                        Slider_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Slider_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "Board_Location_Id", "dbo.Board_Location");
            DropForeignKey("dbo.Boards", "Availability_id", "dbo.Board_Availbality");
            DropIndex("dbo.Boards", new[] { "Availability_id" });
            DropIndex("dbo.Boards", new[] { "Board_Location_Id" });
            DropTable("dbo.sliders");
            DropTable("dbo.Board_Location");
            DropTable("dbo.Board_Availbality");
            DropTable("dbo.Boards");
        }
    }
}
