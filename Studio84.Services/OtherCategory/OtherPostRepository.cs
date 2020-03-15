using Studio84.Model;
using Studio84.Services.Media.Dto;
using Studio84.Services.OtherCategory.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio84.Services
{
    public class OtherPostRepository
    {
        private Studio84DbContext db = null;
        private DbSet<OTHERCATEGORIES> _otherCateRepos = null;
        private DbSet<OTHERPOSTS> _otherPostRepos = null;
        private DbSet<MEDIAS> _mediaRepos = null;

        public OtherPostRepository()
        {
            db = new Studio84DbContext();
            _otherCateRepos = db.Set<OTHERCATEGORIES>();
            _otherPostRepos = db.Set<OTHERPOSTS>();
            _mediaRepos = db.Set<MEDIAS>();
        }

        public List<OtherPostDto> GetAllOtherPost()
        {
            List<OtherPostDto> result = new List<OtherPostDto>();

            try
            {
                var lstPost = _otherPostRepos.ToList();

                foreach (var item in lstPost)
                {
                    OtherPostDto item2 = new OtherPostDto
                    {
                        Id = item.Id,
                        Title = item.Title,
                        OtherCategoryId = item.OtherCategoryId,
                        OtherCategoryName = _otherCateRepos.Find(item.OtherCategoryId).Title,
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

        public OtherPostDto GetById(long id)
        {
            OtherPostDto result = new OtherPostDto();

            try
            {
                var query = _otherPostRepos.Find(id);

                if (query != null)
                {
                    result.Id = query.Id;
                    result.Title = query.Title;
                    result.OtherCategoryId = query.OtherCategoryId;
                    result.OtherCategoryName = _otherCateRepos.Find(query.OtherCategoryId).Title;
                    result.IsActive = query.IsActive;

                    var query2 = _mediaRepos.Where(x => x.PostId == result.Id).ToList();

                    if (query2.Count > 0)
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

        public long CreateOrUpdateOtherPost(OtherPostInputDto input)
        {
            long id = -1;

            try
            {
                if (input.Id.HasValue)
                {
                    id = UpdateOtherPost(input);
                }
                else
                {
                    id = CreateOtherPost(input);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public string DeleteOtherPost(long id)
        {
            string result = "failed";

            try
            {
                var existing = _otherPostRepos.Find(id);

                if (existing != null)
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

                    _otherPostRepos.Remove(existing);
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
        private long CreateOtherPost(OtherPostInputDto input)
        {
            OTHERPOSTS postData = new OTHERPOSTS();
            MEDIAS mediaData = new MEDIAS();

            //Create post
            postData.Title = input.Title;
            postData.OtherCategoryId = input.OtherCategoryId;
            postData.IsActive = input.IsActive;

            _otherPostRepos.Add(postData);
            db.SaveChanges();

            //Create media
            if (input.LstMedia.Count > 0)
            {
                foreach (var item in input.LstMedia)
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

        private long UpdateOtherPost(OtherPostInputDto input)
        {
            OTHERPOSTS postData = new OTHERPOSTS();
            MEDIAS mediaData = new MEDIAS();

            //Update post
            postData.Id = input.Id.Value;
            postData.Title = input.Title;
            postData.OtherCategoryId = input. OtherCategoryId;
            postData.IsActive = input.IsActive;

            _otherPostRepos.Attach(postData);
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
            if (input.LstMedia.Count > 0)
            {
                foreach (var item in input.LstMedia)
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
