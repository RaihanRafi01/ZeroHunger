namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable04NEW : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeliverReqs", "EmpAss_id", "dbo.EmpAssigns");
            DropIndex("dbo.DeliverReqs", new[] { "EmpAss_id" });
            CreateTable(
                "dbo.Deliver_Req",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Assign_id = c.Int(nullable: false),
                        Name = c.String(),
                        Resturant_Name = c.String(),
                        Food_Quality = c.String(),
                        Expire_Date = c.DateTime(nullable: false),
                        Assing_Date = c.DateTime(nullable: false),
                        Status_Delivery = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmpAssigns", t => t.Employee_Assign_id, cascadeDelete: true)
                .Index(t => t.Employee_Assign_id);
            
            
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Deliver_Req", "Employee_Assign_id", "dbo.EmpAssigns");
            DropIndex("dbo.Deliver_Req", new[] { "Employee_Assign_id" });
            DropTable("dbo.Deliver_Req");
            CreateIndex("dbo.DeliverReqs", "EmpAss_id");
            AddForeignKey("dbo.DeliverReqs", "EmpAss_id", "dbo.EmpAssigns", "Id", cascadeDelete: true);
        }
    }
}
