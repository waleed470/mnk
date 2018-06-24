namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boards", "Board_image_id", "dbo.Board_image");
            DropIndex("dbo.Boards", new[] { "Board_image_id" });
            AddColumn("dbo.Board_image", "Board_id", c => c.Int(nullable: false));
            AddColumn("dbo.Board_image", "Board_Broard_Id", c => c.Int());
            CreateIndex("dbo.Board_image", "Board_Broard_Id");
            AddForeignKey("dbo.Board_image", "Board_Broard_Id", "dbo.Boards", "Broard_Id");
            DropColumn("dbo.Boards", "Board_image_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boards", "Board_image_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Board_image", "Board_Broard_Id", "dbo.Boards");
            DropIndex("dbo.Board_image", new[] { "Board_Broard_Id" });
            DropColumn("dbo.Board_image", "Board_Broard_Id");
            DropColumn("dbo.Board_image", "Board_id");
            CreateIndex("dbo.Boards", "Board_image_id");
            AddForeignKey("dbo.Boards", "Board_image_id", "dbo.Board_image", "Board_image_id", cascadeDelete: true);
        }
    }
}
