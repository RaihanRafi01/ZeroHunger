namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table3ADD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Col_id = c.Int(nullable: false),
                        Emp_id = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.Col_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Emp_id, cascadeDelete: true)
                .Index(t => t.Col_id)
                .Index(t => t.Emp_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpAssigns", "Emp_id", "dbo.Employees");
            DropForeignKey("dbo.EmpAssigns", "Col_id", "dbo.Collections");
            DropIndex("dbo.EmpAssigns", new[] { "Emp_id" });
            DropIndex("dbo.EmpAssigns", new[] { "Col_id" });
            DropTable("dbo.EmpAssigns");
        }
    }
}
