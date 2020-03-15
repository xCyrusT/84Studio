using Studio84.Model;
using Studio84.Services.Banner.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class BannerRepository
    {
        private Studio84DbContext db = null;
        private DbSet<BANNERS> _bannerRepos = null;

        public BannerRepository()
        {
            db = new Studio84DbContext();
            _bannerRepos = db.Set<BANNERS>();
        }

        public List<BannerDto> GetAll()
        {
            List<BannerDto> result = new List<BannerDto>();

            try
            {
                var lstCategory = _bannerRepos.ToList();

                foreach (var item in lstCategory)
                {
                    BannerDto item2 = new BannerDto()
                    {
                        Id = item.Id,
                        ImgPath = item.ImgPath,
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

        public BannerDto GetById(long id)
        {
            BannerDto result = new BannerDto();

            try
            {
                var query = _bannerRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.ImgPath = query.ImgPath;
                    result.IsActive = query.IsActive;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public long CreateOrUpdateBanner(BannerInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdateBanner(input);
                }
                else
                {
                    id = CreateBanner(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeleteBanner(long id)
        {
            string result = "failed";

            try
            {
                var existing = _bannerRepos.Find(id);

                _bannerRepos.Remove(existing);
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
        private long CreateBanner(BannerInputDto input)
        {
            BANNERS data = new BANNERS();

            data.ImgPath = input.ImgPath;
            data.IsActive = input.IsActive;

            _bannerRepos.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        private long UpdateBanner(BannerInputDto input)
        {
            BANNERS data = new BANNERS();

            data.Id = input.Id.Value;
            data.ImgPath = input.ImgPath;
            data.IsActive = input.IsActive;

            _bannerRepos.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return data.Id;
        }
    }
}
