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
        private Studio84DbContext db = null;
        private DbSet<PHOTOCATEGORIES> _photoCateRepos = null;
        private DbSet<PHOTOPOSTS> _photoPostRepos = null;

        public PhotoCategoryRepository()
        {
            db = new Studio84DbContext();
            _photoCateRepos = db.Set<PHOTOCATEGORIES>();
            _photoPostRepos = db.Set<PHOTOPOSTS>();
        }

        public List<PhotoCategoryDto> GetAll()
        {
            List<PhotoCategoryDto> result = new List<PhotoCategoryDto>();

            try
            {
                var lstCategory = _photoCateRepos.ToList();

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

        public PhotoCategoryDto GetById(long id)
        {
            PhotoCategoryDto result = new PhotoCategoryDto();

            try
            {
                var query = _photoCateRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.ThumbPath = query.ThumbPath;
                    result.IsActive = query.IsActive;
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
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeletePhotoCategory(long id)
        {
            string result = "failed";

            try
            {
                var existing = _photoCateRepos.Find(id);

                var photoPost = _photoPostRepos.ToList().Where(x => x.PhotoCategoryId == id && x.IsActive == true);

                if (photoPost.ToList().Count == 0)
                {
                    _photoCateRepos.Remove(existing);
                    db.SaveChanges();

                    result = "success";
                }
                else
                {
                    result = "used";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        //Private method
        private long CreatePhotoCategory(PhotoCategoryInputDto input)
        {
            PHOTOCATEGORIES data = new PHOTOCATEGORIES();

            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.IsActive = true;

            _photoCateRepos.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        private long UpdatePhotoCategory(PhotoCategoryInputDto input)
        {
            PHOTOCATEGORIES data = new PHOTOCATEGORIES();

            data.Id = input.Id.Value;
            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.IsActive = input.IsActive;

            _photoCateRepos.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return data.Id;
        }
    }
}
