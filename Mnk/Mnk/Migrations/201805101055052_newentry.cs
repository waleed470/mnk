namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newentry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Gallery_Id = c.Int(nullable: false, identity: true),
                        Gallery_title = c.String(nullable: false),
                        Gallery_image = c.String(nullable: false),
                        Gallery_status = c.Boolean(nullable: false),
                        Gallery_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Gallery_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
