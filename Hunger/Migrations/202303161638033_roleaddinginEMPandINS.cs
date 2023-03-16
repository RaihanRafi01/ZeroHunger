namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleaddinginEMPandINS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Institutions", "Role", c => c.String());
            AddColumn("dbo.Employees", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Role");
            DropColumn("dbo.Institutions", "Role");
        }
    }
}
