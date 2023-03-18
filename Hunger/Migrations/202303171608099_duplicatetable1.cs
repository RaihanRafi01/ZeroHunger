namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class duplicatetable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duplicate_Coll",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ins_id = c.Int(nullable: false),
                        FoodQty = c.String(),
                        ReqDate = c.DateTime(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Duplicate_Coll");
        }
    }
}
