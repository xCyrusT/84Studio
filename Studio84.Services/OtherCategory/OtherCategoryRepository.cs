using Studio84.Model;
using Studio84.Services.OtherCategory.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class OtherCategoryRepository
    {
        private Studio84DbContext db = null;
        private DbSet<OTHERCATEGORIES> _otherCateRepos = null;
        private DbSet<OTHERPOSTS> _otherPostRepos = null;

        public OtherCategoryRepository()
        {
            db = new Studio84DbContext();
            _otherCateRepos = db.Set<OTHERCATEGORIES>();
            _otherPostRepos = db.Set<OTHERPOSTS>();
        }

        public List<OtherCategoryDto> GetAll()
        {
            List<OtherCategoryDto> result = new List<OtherCategoryDto>();

            try
            {
                var lstCategory = _otherCateRepos.ToList();

                foreach (var item in lstCategory)
                {
                    OtherCategoryDto item2 = new OtherCategoryDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        ThumbPath = item.ThumbPath,
                        IsRoot = item.IsRoot,
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

        public OtherCategoryDto GetById(long id)
        {
            OtherCategoryDto result = new OtherCategoryDto();

            try
            {
                var query = _otherCateRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.ThumbPath = query.ThumbPath;
                    result.IsRoot = query.IsRoot;
                    result.IsActive = query.IsActive;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public long CreateOrUpdateOtherCategory(OtherCategoryInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdateOtherCategory(input);
                }
                else
                {
                    id = CreateOtherCategory(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeleteOtherCategory(long id)
        {
            string result = "failed";

            try
            {
                var existing = _otherCateRepos.Find(id);

                var otherPost = _otherPostRepos.ToList().Where(x => x.OtherCategoryId == id && x.IsActive == true);

                if (otherPost.ToList().Count == 0)
                {
                    _otherCateRepos.Remove(existing);
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
        private long CreateOtherCategory(OtherCategoryInputDto input)
        {
            OTHERCATEGORIES data = new OTHERCATEGORIES();

            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.IsRoot = input.IsRoot;
            data.IsActive = input.IsActive;

            _otherCateRepos.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        private long UpdateOtherCategory(OtherCategoryInputDto input)
        {
            OTHERCATEGORIES data = new OTHERCATEGORIES();

            data.Id = input.Id.Value;
            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.IsRoot = input.IsRoot;
            data.IsActive = input.IsActive;

            _otherCateRepos.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return data.Id;
        }
    }
}
