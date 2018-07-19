namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.real_form", "site_name", c => c.String(nullable: false));
            AlterColumn("dbo.real_form", "area", c => c.String(nullable: false));
            AlterColumn("dbo.real_form", "banner_size", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.real_form", "banner_size", c => c.String());
            AlterColumn("dbo.real_form", "area", c => c.String());
            AlterColumn("dbo.real_form", "site_name", c => c.String());
        }
    }
}
