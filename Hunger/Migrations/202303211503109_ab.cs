namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ab : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Duplicate_Coll", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Duplicate_Coll", "Status", c => c.String());
        }
    }
}
