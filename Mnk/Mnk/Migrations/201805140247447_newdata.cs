namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.testo_nomia",
                c => new
                    {
                        Testo_nomia_Id = c.Int(nullable: false, identity: true),
                        Testo_nomia_name = c.String(nullable: false),
                        Testo_nomia_Massage = c.String(nullable: false),
                        Testo_nomia_image = c.String(),
                        testo_nomia_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Testo_nomia_Id);
            
            AddColumn("dbo.Board_Availbality", "Availability_status", c => c.String(nullable: false));
            AddColumn("dbo.Board_Availbality", "Availability_Date", c => c.String(nullable: false));
            AddColumn("dbo.Board_Location", "Board_location_Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Board_Location", "Board_location_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Board_Location", "Board_City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Board_Location", "Board_City", c => c.String(nullable: false));
            DropColumn("dbo.Board_Location", "Board_location_Date");
            DropColumn("dbo.Board_Location", "Board_location_Status");
            DropColumn("dbo.Board_Availbality", "Availability_Date");
            DropColumn("dbo.Board_Availbality", "Availability_status");
            DropTable("dbo.testo_nomia");
        }
    }
}
