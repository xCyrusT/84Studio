namespace Studio84.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_PhotoPost_Add_Column_ThumbPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhotoPosts", "ThumbPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhotoPosts", "ThumbPath");
        }
    }
}
