namespace Studio84.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThuLK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banners", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banners", "IsActive");
        }
    }
}
