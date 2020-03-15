using Studio84.Services;
using Studio84.Services.OtherCategory.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class OtherPostController : Controller
    {
        private OtherPostRepository otherPostRepo = null;
        private OtherCategoryRepository otherCateRepo = null;

        public OtherPostController()
        {
            otherPostRepo = new OtherPostRepository();
            otherCateRepo = new OtherCategoryRepository();
        }

        // GET: Administrator/OtherPost
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllOtherCategory()
        {
            JsonResult result = new JsonResult();

            List<OtherCategoryDto> lstCate = otherCateRepo.GetAll().Where(x => x.IsActive == true && x.IsRoot == true).ToList();

            result.Data = lstCate;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllOtherPost()
        {
            JsonResult result = new JsonResult();

            List<OtherPostDto> lst = otherPostRepo.GetAllOtherPost();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdateOtherPost(OtherPostInputDto data)
        {
            return Json(otherPostRepo.CreateOrUpdateOtherPost(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOtherPostById(long id)
        {
            JsonResult result = new JsonResult();

            OtherPostDto data = otherPostRepo.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOtherPost(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = otherPostRepo.DeleteOtherPost(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}