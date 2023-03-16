namespace Hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerole : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Institutions", "Role");
            DropColumn("dbo.Employees", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Role", c => c.String());
            AddColumn("dbo.Institutions", "Role", c => c.String());
        }
    }
}
