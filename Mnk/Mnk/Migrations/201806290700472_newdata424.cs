namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata424 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board_booking",
                c => new
                    {
                        Board_booking_id = c.Int(nullable: false, identity: true),
                        Booking_type = c.String(),
                        Booking_to = c.DateTime(nullable: false),
                        Booking_from = c.DateTime(nullable: false),
                        Broard_Id = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Board_booking_id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Broard_Id, cascadeDelete: true)
                .Index(t => t.Broard_Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Board_booking", "Broard_Id", "dbo.Boards");
            DropForeignKey("dbo.Board_booking", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Board_booking", new[] { "Id" });
            DropIndex("dbo.Board_booking", new[] { "Broard_Id" });
            DropTable("dbo.Board_booking");
        }
    }
}
