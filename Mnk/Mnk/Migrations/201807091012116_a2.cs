namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.real_form",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        site_name = c.String(),
                        area = c.String(),
                        banner_size = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.real_form");
        }
    }
}
