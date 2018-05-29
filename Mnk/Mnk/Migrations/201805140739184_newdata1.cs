namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Board_Availbality", "Availability_status", c => c.String());
            AlterColumn("dbo.Board_Availbality", "Availability_Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Board_Availbality", "Availability_Date", c => c.String(nullable: false));
            AlterColumn("dbo.Board_Availbality", "Availability_status", c => c.String(nullable: false));
        }
    }
}
