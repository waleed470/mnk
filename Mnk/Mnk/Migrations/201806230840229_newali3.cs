namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newali3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact_us", "Contact_phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact_us", "Contact_phone");
        }
    }
}
