using Studio84.Model;
using Studio84.Services.Photo.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class PhotoCategoryRepository
    {
        protected Studio84DbContext db = null;
        protected DbSet<PHOTOCATEGORIES> table = null;

        public PhotoCategoryRepository()
        {
            db = new Studio84DbContext();
            table = db.Set<PHOTOCATEGORIES>();
        }

        public List<PhotoCategoryDto> GetAll()
        {
            List<PhotoCategoryDto> result = new List<PhotoCategoryDto>();

            try
            {
                var lstCategory = table.ToList();

                foreach (var item in lstCategory)
                {
                    PhotoCategoryDto item2 = new PhotoCategoryDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        ThumbPath = item.ThumbPath,
                        IsActive = item.IsActive
                    };

                    result.Add(item2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public long CreateOrUpdatePhotoCategory(PhotoCategoryInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdatePhotoCategory(input);
                }
                else
                {
                    id = CreatePhotoCategory(input);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return id;
        }

        public long CreatePhotoCategory(PhotoCategoryInputDto input)
        {
            PHOTOCATEGORIES data = new PHOTOCATEGORIES();

            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.IsActive = true;

            db.PhotoCategories.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        public long UpdatePhotoCategory(PhotoCategoryInputDto input)
        {
            PHOTOCATEGORIES data = new PHOTOCATEGORIES();

            data.Id = input.Id.Value;
            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.IsActive = input.IsActive;

            db.PhotoCategories.Attach(data);
            db.SaveChanges();

            return data.Id;
        }
    }
}
