namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExtraDATAonTABLE4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Delivers", "EmpAss_id", "dbo.EmpAssigns");
            DropIndex("dbo.Delivers", new[] { "EmpAss_id" });
            CreateTable(
                "dbo.DeliverReqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpAss_id = c.Int(nullable: false),
                        Name = c.String(),
                        ResName = c.String(),
                        FoodQty = c.String(),
                        ExpDate = c.DateTime(nullable: false),
                        AssingDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmpAssigns", t => t.EmpAss_id, cascadeDelete: true)
                .Index(t => t.EmpAss_id);
            
            DropTable("dbo.Delivers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Delivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpAss_id = c.Int(nullable: false),
                        Name = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.DeliverReqs", "EmpAss_id", "dbo.EmpAssigns");
            DropIndex("dbo.DeliverReqs", new[] { "EmpAss_id" });
            DropTable("dbo.DeliverReqs");
            CreateIndex("dbo.Delivers", "EmpAss_id");
            AddForeignKey("dbo.Delivers", "EmpAss_id", "dbo.EmpAssigns", "Id", cascadeDelete: true);
        }
    }
}
