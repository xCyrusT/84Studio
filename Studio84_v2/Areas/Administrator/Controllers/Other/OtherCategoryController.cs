using Studio84.Services.OtherCategory;
using Studio84.Services.OtherCategory.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class OtherCategoryController : Controller
    {
        private OtherCategoryRepository otherCateRepos = null;

        public OtherCategoryController()
        {
            otherCateRepos = new OtherCategoryRepository();
        }

        // GET: Administrator/OtherCategory
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllOtherCategory()
        {
            JsonResult result = new JsonResult();

            List<OtherCategoryDto> lst = otherCateRepos.GetAll();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOtherCategoryById(long id)
        {
            JsonResult result = new JsonResult();

            OtherCategoryDto data = otherCateRepos.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdateOtherCategory(OtherCategoryInputDto data)
        {
            return Json(otherCateRepos.CreateOrUpdateOtherCategory(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOtherCategory(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = otherCateRepos.DeleteOtherCategory(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
