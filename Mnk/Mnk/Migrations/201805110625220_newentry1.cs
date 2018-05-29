namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newentry1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Team_Member_Id = c.Int(nullable: false, identity: true),
                        Team_member_Name = c.String(nullable: false),
                        Team_member_Designation = c.String(nullable: false),
                        Team_member_image = c.String(),
                        Team_member_status = c.Boolean(nullable: false),
                        Team_member_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Team_Member_Id);
            
            AlterColumn("dbo.Galleries", "Gallery_image", c => c.String());
            AlterColumn("dbo.sliders", "Slider_Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.sliders", "Slider_Image", c => c.String(nullable: false));
            AlterColumn("dbo.Galleries", "Gallery_image", c => c.String(nullable: false));
            DropTable("dbo.Teams");
        }
    }
}
