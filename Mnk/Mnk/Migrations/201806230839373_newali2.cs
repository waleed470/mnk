namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newali2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact_us", "Contact_phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact_us", "Contact_phone", c => c.Int(nullable: false));
        }
    }
}
