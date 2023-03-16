namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_table1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ins_id = c.Int(nullable: false),
                        FoodQty = c.String(),
                        ReqDate = c.String(),
                        ExpDate = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.Ins_id, cascadeDelete: true)
                .Index(t => t.Ins_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "Ins_id", "dbo.Institutions");
            DropIndex("dbo.Collections", new[] { "Ins_id" });
            DropTable("dbo.Collections");
        }
    }
}
