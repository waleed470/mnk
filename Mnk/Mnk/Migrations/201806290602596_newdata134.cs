namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata134 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.real_estate",
                c => new
                    {
                        real_id = c.Int(nullable: false, identity: true),
                        real_name = c.String(),
                        real_discription = c.String(),
                        real_image = c.String(),
                        real_status = c.Boolean(nullable: false),
                        real_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.real_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.real_estate");
        }
    }
}
