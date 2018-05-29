namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdtaa7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Board_Availbality", "Availability_to", c => c.DateTime(nullable: false));
            AddColumn("dbo.Board_Availbality", "Availability_from", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Board_Availbality", "Availability_from");
            DropColumn("dbo.Board_Availbality", "Availability_to");
        }
    }
}
