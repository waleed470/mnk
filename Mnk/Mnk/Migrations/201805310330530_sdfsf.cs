namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Board_Availbality", "Availability_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Board_Availbality", "Availability_Date");
        }
    }
}
