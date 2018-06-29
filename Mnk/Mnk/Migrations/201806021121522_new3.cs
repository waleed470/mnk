namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board_image",
                c => new
                    {
                        Board_image_id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.Board_image_id);
            
            AddColumn("dbo.Boards", "Board_image_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Boards", "Board_image_id");
            AddForeignKey("dbo.Boards", "Board_image_id", "dbo.Board_image", "Board_image_id", cascadeDelete: true);
            DropColumn("dbo.Board_Availbality", "Availability_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Board_Availbality", "Availability_name", c => c.String(nullable: false));
            DropForeignKey("dbo.Boards", "Board_image_id", "dbo.Board_image");
            DropIndex("dbo.Boards", new[] { "Board_image_id" });
            DropColumn("dbo.Boards", "Board_image_id");
            DropTable("dbo.Board_image");
        }
    }
}
