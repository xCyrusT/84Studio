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
    public class PricePostRepository
    {
        private Studio84DbContext db = null;
        private DbSet<PRICECATEGORIES> _priceCateRepos = null;
        private DbSet<PRICEPOSTS> _pricePostRepos = null;

        public PricePostRepository()
        {
            db = new Studio84DbContext();
            _priceCateRepos = db.Set<PRICECATEGORIES>();
            _pricePostRepos = db.Set<PRICEPOSTS>();
        }

        public List<PricePostDto> GetAll()
        {
            List<PricePostDto> result = new List<PricePostDto>();

            try
            {
                var lstCategory = _pricePostRepos.ToList();

                foreach (var item in lstCategory)
                {
                    PricePostDto item2 = new PricePostDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        PriceCategoryId = item.PriceCategoryId,
                        PriceCategoryName = _priceCateRepos.Find(item.PriceCategoryId).Title,
                        Description = item.Description,
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

        public PricePostDto GetById(long id)
        {
            PricePostDto result = new PricePostDto();

            try
            {
                var query = _pricePostRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.PriceCategoryId = query.PriceCategoryId;
                    result.PriceCategoryName = _priceCateRepos.Find(query.PriceCategoryId).Title;
                    result.Description = query.Description;
                    result.IsActive = query.IsActive;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public long CreateOrUpdatePricePost(PricePostInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdatePricePost(input);
                }
                else
                {
                    id = CreatePricePost(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeletePricePost(long id)
        {
            string result = "failed";

            try
            {
                var existing = _pricePostRepos.Find(id);

                _pricePostRepos.Remove(existing);
                db.SaveChanges();

                result = "success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        //Private method
        private long CreatePricePost(PricePostInputDto input)
        {
            PRICEPOSTS data = new PRICEPOSTS();

            data.Title = input.Title;
            data.PriceCategoryId = input.PriceCategoryId;
            data.Description = input.Description;
            data.IsActive = input.IsActive;

            _pricePostRepos.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        private long UpdatePricePost(PricePostInputDto input)
        {
            PRICEPOSTS data = new PRICEPOSTS();

            data.Id = input.Id.Value;
            data.Title = input.Title;
            data.PriceCategoryId = input.PriceCategoryId;
            data.Description = input.Description;
            data.IsActive = input.IsActive;

            _pricePostRepos.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return data.Id;
        }
    }
}
