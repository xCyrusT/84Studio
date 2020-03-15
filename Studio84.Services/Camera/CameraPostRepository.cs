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
    public class CameraPostRepository
    {
        private Studio84DbContext db = null;
        private DbSet<CAMERACATEGORIES> _cameraCateRepos = null;
        private DbSet<CAMERAPOSTS> _cameraPostRepos = null;

        public CameraPostRepository()
        {
            db = new Studio84DbContext();

            _cameraCateRepos = db.Set<CAMERACATEGORIES>();
            _cameraPostRepos = db.Set<CAMERAPOSTS>();
        }

        public List<CameraPostDto> GetAllCameraPost()
        {
            List<CameraPostDto> result = new List<CameraPostDto>();

            try
            {
                var lstPost = _cameraPostRepos.ToList();

                foreach (var item in lstPost)
                {
                    CameraPostDto item2 = new CameraPostDto
                    {
                        Id = item.Id,
                        Title = item.Title,
                        CameraCategoryId = item.CameraCategoryId,
                        CameraCategoryName = _cameraCateRepos.Find(item.CameraCategoryId).Title,
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

        public CameraPostDto GetById(long id)
        {
            CameraPostDto result = new CameraPostDto();

            try
            {
                var query = _cameraPostRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.CameraCategoryId = query.CameraCategoryId;
                    result.CameraCategoryName = _cameraCateRepos.Find(query.CameraCategoryId).Title;
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

        public long CreateOrUpdateCameraPost(CameraPostInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdateCameraPost(input);
                }
                else
                {
                    id = CreateCameraPost(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeleteCameraPost(long id)
        {
            string result = "failed";

            try
            {
                var existing = _cameraPostRepos.Find(id);

                _cameraPostRepos.Remove(existing);
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
        private long CreateCameraPost(CameraPostInputDto input)
        {
            CAMERAPOSTS postData = new CAMERAPOSTS();

            //Create post
            postData.Title = input.Title;
            postData.CameraCategoryId = input.CameraCategoryId;
            postData.ThumbPath = input.ThumbPath;
            postData.VideoUrl = input.VideoUrl;
            postData.IsActive = input.IsActive;

            _cameraPostRepos.Add(postData);
            db.SaveChanges();

            return postData.Id;
        }

        private long UpdateCameraPost(CameraPostInputDto input)
        {
            CAMERAPOSTS postData = new CAMERAPOSTS();

            //Update post
            postData.Id = input.Id.Value;
            postData.Title = input.Title;
            postData.CameraCategoryId = input.CameraCategoryId;
            postData.ThumbPath = input.ThumbPath;
            postData.VideoUrl = input.VideoUrl;
            postData.IsActive = input.IsActive;

            _cameraPostRepos.Attach(postData);
            db.Entry(postData).State = EntityState.Modified;

            db.SaveChanges();

            return postData.Id;
        }
    }
}
