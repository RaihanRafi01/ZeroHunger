namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addduplicaterelation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Duplicate_Coll", "Ins_id");
            AddForeignKey("dbo.Duplicate_Coll", "Ins_id", "dbo.Institutions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Duplicate_Coll", "Ins_id", "dbo.Institutions");
            DropIndex("dbo.Duplicate_Coll", new[] { "Ins_id" });
        }
    }
}
