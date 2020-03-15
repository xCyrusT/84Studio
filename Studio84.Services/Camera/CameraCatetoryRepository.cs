using Studio84.Model;
using Studio84.Services.Camera.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class CameraCatetoryRepository
    {
        private Studio84DbContext db = null;
        private DbSet<CAMERACATEGORIES> _cameraCateRepos = null;
        private DbSet<CAMERAPOSTS> _cameraPostRepos = null;

        public CameraCatetoryRepository()
        {
            db = new Studio84DbContext();

            _cameraCateRepos = db.Set<CAMERACATEGORIES>();
            _cameraPostRepos = db.Set<CAMERAPOSTS>();
        }

        public List<CameraCategoryDto> GetAll()
        {
            List<CameraCategoryDto> result = new List<CameraCategoryDto>();

            try
            {
                var lstCategory = _cameraCateRepos.ToList();

                foreach (var item in lstCategory)
                {
                    CameraCategoryDto item2 = new CameraCategoryDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        ThumbPath = item.ThumbPath,
                        VideoUrl = item.VideoUrl,
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

        public CameraCategoryDto GetById(long id)
        {
            CameraCategoryDto result = new CameraCategoryDto();

            try
            {
                var query = _cameraCateRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.ThumbPath = query.ThumbPath;
                    result.VideoUrl = query.VideoUrl;
                    result.IsActive = query.IsActive;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public long CreateOrUpdateCameraCategory(CameraCategoryInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdateCameraCategory(input);
                }
                else
                {
                    id = CreateCameraCategory(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeleteCameraCategory(long id)
        {
            string result = "failed";

            try
            {
                var existing = _cameraCateRepos.Find(id);

                var photoPost = _cameraPostRepos.ToList().Where(x => x.CameraCategoryId == id && x.IsActive == true);

                if (photoPost.ToList().Count == 0)
                {
                    _cameraCateRepos.Remove(existing);
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
        private long CreateCameraCategory(CameraCategoryInputDto input)
        {
            CAMERACATEGORIES data = new CAMERACATEGORIES();

            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.VideoUrl = input.VideoUrl;
            data.IsActive = input.IsActive;

            _cameraCateRepos.Add(data);

            db.SaveChanges();

            return data.Id;
        }

        private long UpdateCameraCategory(CameraCategoryInputDto input)
        {
            CAMERACATEGORIES data = new CAMERACATEGORIES();

            data.Id = input.Id.Value;
            data.Title = input.Title;
            data.ThumbPath = input.ThumbPath;
            data.VideoUrl = input.VideoUrl;
            data.IsActive = input.IsActive;

            _cameraCateRepos.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return data.Id;
        }
    }
}
