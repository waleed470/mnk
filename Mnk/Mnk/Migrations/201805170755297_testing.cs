namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Board_Availbality", "Availability_status");
            DropColumn("dbo.Board_Availbality", "Availability_Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Board_Availbality", "Availability_Date", c => c.String());
            AddColumn("dbo.Board_Availbality", "Availability_status", c => c.String());
        }
    }
}
