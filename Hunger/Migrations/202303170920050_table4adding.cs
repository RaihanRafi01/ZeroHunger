namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table4adding : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Delivers", "Emp_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Delivers", "Emp_Id", c => c.Int(nullable: false));
        }
    }
}
