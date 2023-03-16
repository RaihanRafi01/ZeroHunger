namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Collections", "ReqDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Collections", "ExpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collections", "ExpDate", c => c.String());
            AlterColumn("dbo.Collections", "ReqDate", c => c.String());
        }
    }
}
