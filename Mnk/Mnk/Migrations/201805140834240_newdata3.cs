namespace Mnk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board_city",
                c => new
                    {
                        Board_City_Id = c.Int(nullable: false, identity: true),
                        Board_City_name = c.String(nullable: false),
                        Board_City_Status = c.Boolean(nullable: false),
                        Board_City_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Board_City_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Board_city");
        }
    }
}
