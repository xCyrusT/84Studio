namespace Studio84.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_PriceCategory_Alter_Column_Description : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PriceCategories", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PriceCategories", "Description", c => c.String(maxLength: 4000));
        }
    }
}
