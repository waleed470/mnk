namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newentry12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services_details", "service_Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Services_details", "service_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services_details", "service_Date", c => c.String());
            AlterColumn("dbo.Services_details", "service_Status", c => c.String());
        }
    }
}
