namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board_medium",
                c => new
                    {
                        Board_Medium_Id = c.Int(nullable: false, identity: true),
                        Board_Medium_name = c.String(nullable: false),
                        Board_Medium_Status = c.Boolean(nullable: false),
                        Board_Medium_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Board_Medium_Id);
            
            CreateTable(
                "dbo.clients",
                c => new
                    {
                        Client_Id = c.Int(nullable: false, identity: true),
                        Client_name = c.String(nullable: false),
                        Client_image = c.String(),
                        Client_status = c.Boolean(nullable: false),
                        Client_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Client_Id);
            
            CreateTable(
                "dbo.Services_details",
                c => new
                    {
                        Service_Detail_Id = c.Int(nullable: false, identity: true),
                        Service_Detail_Name = c.String(nullable: false),
                        Service_Detail_Description = c.String(nullable: false),
                        Service_Detail_Image = c.String(),
                        service_Status = c.String(),
                        service_Date = c.String(),
                        Service_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Service_Detail_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.Service_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services_details", "Service_Id", "dbo.Services");
            DropIndex("dbo.Services_details", new[] { "Service_Id" });
            DropTable("dbo.Services_details");
            DropTable("dbo.clients");
            DropTable("dbo.Board_medium");
        }
    }
}
