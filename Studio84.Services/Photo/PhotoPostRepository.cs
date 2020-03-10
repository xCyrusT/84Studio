using Studio84.Model;
using Studio84.Services.Media.Dto;
using Studio84.Services.Photo.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class PhotoPostRepository
    {
        private Studio84DbContext db = null;
        private DbSet<PHOTOCATEGORIES> _photoCateRepos = null;
        private DbSet<PHOTOPOSTS> _photoPostRepos = null;
        private DbSet<MEDIAS> _mediaRepos = null;

        public PhotoPostRepository()
        {
            db = new Studio84DbContext();
            _photoCateRepos = db.Set<PHOTOCATEGORIES>();
            _photoPostRepos = db.Set<PHOTOPOSTS>();
            _mediaRepos = db.Set<MEDIAS>();
        }

        public List<PhotoPostDto> GetAllPhotoPost()
        {
            List<PhotoPostDto> result = new List<PhotoPostDto>();

            try
            {
                var lstPost = _photoPostRepos.ToList();

                foreach (var item in lstPost)
                {
                    PhotoPostDto item2 = new PhotoPostDto
                    {
                        Id = item.Id,
                        Title = item.Title,
                        PhotoCategoryId = item.PhotoCategoryId,
                        PhotoCategoryName = _photoCateRepos.Find(item.PhotoCategoryId).Title,
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

        public PhotoPostDto GetById(long id)
        {
            PhotoPostDto result = new PhotoPostDto();

            try
            {
                var query = _photoPostRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.PhotoCategoryId = query.PhotoCategoryId;
                    result.PhotoCategoryName = _photoCateRepos.Find(query.PhotoCategoryId).Title;
                    result.IsActive = query.IsActive;

                    var query2 = _mediaRepos.Where(x => x.PostId == result.Id).ToList();

                    if (query2.Count>0)
                    {
                        List<MediaDto> lstMedia = new List<MediaDto>();
                        foreach (var item in query2)
                        {
                            var media = new MediaDto
                            {
                                Id = item.Id,
                                PostId = item.PostId,
                                ImgPath = item.ImgPath
                            };

                            lstMedia.Add(media);
                        }

                        result.LstMedia = lstMedia;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public long CreateOrUpdatePhotoPost(PhotoPostInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdatePhotoPost(input);
                }
                else
                {
                    id = CreatePhotoPost(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeletePhotoPost(long id)
        {
            string result = "failed";

            try
            {
                var existing = _photoPostRepos.Find(id);

                if (existing !=null)
                {
                    var query = _mediaRepos.Where(x => x.PostId == id).ToList();
                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            _mediaRepos.Remove(item);
                        }
                        db.SaveChanges();
                    }

                    _photoPostRepos.Remove(existing);
                    db.SaveChanges();
                }

                result = "success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        //Private method
        private long CreatePhotoPost(PhotoPostInputDto input)
        {
            PHOTOPOSTS postData = new PHOTOPOSTS();
            MEDIAS mediaData = new MEDIAS();

            //Create post
            postData.Title = input.Title;
            postData.PhotoCategoryId = input.PhotoCategoryId;
            postData.IsActive = true;

            _photoPostRepos.Add(postData);
            db.SaveChanges();

            //Create media
            if (input.LstMedias.Count > 0)
            {
                foreach (var item in input.LstMedias)
                {
                    if (!string.IsNullOrEmpty(item.ImgPath))
                    {
                        mediaData = new MEDIAS
                        {
                            PostId = postData.Id,
                            ImgPath = item.ImgPath
                        };

                        _mediaRepos.Add(mediaData);
                    }
                }
                db.SaveChanges();
            }

            return postData.Id;
        }

        private long UpdatePhotoPost(PhotoPostInputDto input)
        {
            PHOTOPOSTS postData = new PHOTOPOSTS();
            MEDIAS mediaData = new MEDIAS();

            //Update post
            postData.Id = input.Id.Value;
            postData.Title = input.Title;
            postData.PhotoCategoryId = input.PhotoCategoryId;
            postData.IsActive = input.IsActive;

            _photoPostRepos.Attach(postData);
            db.Entry(postData).State = EntityState.Modified;

            db.SaveChanges();

            ////Media
            //Delete old medias
            List<MEDIAS> lstMedias = _mediaRepos.Where(x => x.PostId == input.Id.Value).ToList();
            if (lstMedias.Count > 0)
            {
                foreach (var item in lstMedias)
                {
                    _mediaRepos.Remove(item);
                }

                db.SaveChanges();
            }

            //Add new medias
            if (input.LstMedias.Count > 0)
            {
                foreach (var item in input.LstMedias)
                {
                    if (!string.IsNullOrEmpty(item.ImgPath))
                    {
                        mediaData = new MEDIAS
                        {
                            PostId = postData.Id,
                            ImgPath = item.ImgPath
                        };

                        _mediaRepos.Add(mediaData);
                    }
                }

                db.SaveChanges();
            }

            return postData.Id;
        }
    }
}
