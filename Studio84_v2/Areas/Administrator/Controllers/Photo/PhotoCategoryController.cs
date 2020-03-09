using Studio84.Services;
using Studio84.Services.Photo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class PhotoCategoryController : Controller
    {
        private PhotoCategoryRepository photoRepos = null;

        public PhotoCategoryController()
        {
            photoRepos = new PhotoCategoryRepository();
        }

        // GET: Administrator/PhotoCategory
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllPhotoCategory()
        {
            JsonResult result = new JsonResult();

            List<PhotoCategoryDto> lst = photoRepos.GetAll();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPhotoCategoryById(long id)
        {
            JsonResult result = new JsonResult();

            PhotoCategoryDto data = photoRepos.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdatePhotoCategory(PhotoCategoryInputDto data)
        {
            return Json(photoRepos.CreateOrUpdatePhotoCategory(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePhotoCategory(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = photoRepos.DeletePhotoCategory(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
