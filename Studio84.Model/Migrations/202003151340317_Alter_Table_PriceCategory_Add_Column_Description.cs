namespace Studio84.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_PriceCategory_Add_Column_Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PriceCategories", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PriceCategories", "Description");
        }
    }
}
