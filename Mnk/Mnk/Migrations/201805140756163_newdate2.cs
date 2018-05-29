namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Board_Location", "Board_location_name", c => c.String(nullable: false));
            DropColumn("dbo.Board_Location", "Board_location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Board_Location", "Board_location", c => c.String(nullable: false));
            DropColumn("dbo.Board_Location", "Board_location_name");
        }
    }
}
