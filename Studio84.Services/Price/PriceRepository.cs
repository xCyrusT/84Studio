using Studio84.Model;
using Studio84.Services.Price.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class PriceRepository
    {
        private Studio84DbContext db = null;
        private DbSet<PRICECATEGORIES> _priceCateRepos = null;
        private DbSet<PRICEPOSTS> _pricePostRepos = null;

        public PriceRepository()
        {
            db = new Studio84DbContext();
            _priceCateRepos = db.Set<PRICECATEGORIES>();
            _pricePostRepos = db.Set<PRICEPOSTS>();
        }

        public List<PriceCategoryDto> GetAll()
        {
            List<PriceCategoryDto> result = new List<PriceCategoryDto>();

            try
            {
                var lstCategory = _priceCateRepos.ToList();

                foreach (var item in lstCategory)
                {
                    PriceCategoryDto item2 = new PriceCategoryDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
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

        public PriceCategoryDto GetById(long id)
        {
            PriceCategoryDto result = new PriceCategoryDto();

            try
            {
                var query = _priceCateRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.Description = query.Description;
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

        public long CreateOrUpdatePriceCategory(PriceCategoryInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdatePriceCategory(input);
                }
                else
                {
                    id = CreatePriceCategory(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeletePriceCategory(long id)
        {
            string result = "failed";

            try
            {
                var existing = _priceCateRepos.Find(id);

                var pricePost = _pricePostRepos.ToList().Where(x => x.PriceCategoryId == id && x.IsActive == true);

                if (pricePost.ToList().Count == 0)
                {
                    _priceCateRepos.Remove(existing);
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
        private long CreatePriceCategory(PriceCategoryInputDto input)
        {
            PRICECATEGORIES data = new PRICECATEGORIES();

            data.Title = input.Title;
            data.Description = input.Description;
            data.ThumbPath = input.ThumbPath;
            data.IsActive = input.IsActive;

            _priceCateRepos.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        private long UpdatePriceCategory(PriceCategoryInputDto input)
        {
            PRICECATEGORIES data = new PRICECATEGORIES();

            data.Id = input.Id.Value;
            data.Title = input.Title;
            data.Description = input.Description;
            data.ThumbPath = input.ThumbPath;
            data.IsActive = input.IsActive;

            _priceCateRepos.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return data.Id;
        }
    }
}
