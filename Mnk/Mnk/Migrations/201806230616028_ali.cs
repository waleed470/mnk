namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ali : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact_us",
                c => new
                    {
                        Contact_Id = c.Int(nullable: false, identity: true),
                        Contact_Name = c.Int(nullable: false),
                        Contact_email = c.String(nullable: false),
                        Contact_subject = c.String(),
                        Contact_Message = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contact_us");
        }
    }
}
