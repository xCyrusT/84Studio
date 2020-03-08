using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Model
{
    public class Studio84DbContext : DbContext
    {
        public Studio84DbContext() : base("Studio84DbContext")
        {
        }

        public DbSet<ROLES> Roles { get; set; }
        public DbSet<USERS> Users { get; set; }
        public DbSet<PHOTOCATEGORIES> PhotoCategories { get; set; }
        public DbSet<PHOTOPOSTS> PhotoPosts { get; set; }
        public DbSet<CAMERACATEGORIES> CameraCategories { get; set; }
        public DbSet<CAMERAPOSTS> CameraPosts { get; set; }
        public DbSet<OTHERCATEGORIES> OtherCategories { get; set; }
        public DbSet<OTHERPOSTS> OtherPosts { get; set; }
        public DbSet<PRICECATEGORIES> PriceCategories { get; set; }
        public DbSet<PRICEPOSTS> PricePosts { get; set; }
        public DbSet<BANNERS> Banners { get; set; }
        public DbSet<MEDIAS> Medias { get; set; }
        public DbSet<FEEDBACKS> Feedbacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
