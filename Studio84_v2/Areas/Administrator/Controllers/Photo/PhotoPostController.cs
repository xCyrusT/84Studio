using Studio84.Services;
using Studio84.Services.Photo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class PhotoPostController : Controller
    {
        private PhotoPostRepository photoPostRepo = null;
        private PhotoCategoryRepository photoCateRepo = null;

        public PhotoPostController()
        {
            photoPostRepo = new PhotoPostRepository();
            photoCateRepo = new PhotoCategoryRepository();
        }

        // GET: Administrator/PhotoPost
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllPhotoCategory()
        {
            JsonResult result = new JsonResult();

            List<PhotoCategoryDto> lstCate = photoCateRepo.GetAll().Where(x => x.IsActive == true).ToList();

            result.Data = lstCate;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllPhotoPost()
        {
            JsonResult result = new JsonResult();

            List<PhotoPostDto> lst = photoPostRepo.GetAllPhotoPost();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdatePhotoPost(PhotoPostInputDto data)
        {
            return Json(photoPostRepo.CreateOrUpdatePhotoPost(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPhotoPostById(long id)
        {
            JsonResult result = new JsonResult();

            PhotoPostDto data = photoPostRepo.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePhotoPost(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = photoPostRepo.DeletePhotoPost(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
