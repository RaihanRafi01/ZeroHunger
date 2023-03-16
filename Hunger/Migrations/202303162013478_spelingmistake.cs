namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spelingmistake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmpAssigns", "AssignDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmpAssigns", "AssignDate");
        }
    }
}
