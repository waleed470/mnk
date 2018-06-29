namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newentry66 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "Broard_Site_code", c => c.String());
            AlterColumn("dbo.Boards", "Broard_Traffic_from", c => c.String());
            AlterColumn("dbo.Boards", "Broard_Traffic_to", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boards", "Broard_Traffic_to", c => c.String(nullable: false));
            AlterColumn("dbo.Boards", "Broard_Traffic_from", c => c.String(nullable: false));
            AlterColumn("dbo.Boards", "Broard_Site_code", c => c.String(nullable: false));
        }
    }
}
