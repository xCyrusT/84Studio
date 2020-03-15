using Studio84.Services;
using Studio84.Services.Price.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class PriceCategoryController : Controller
    {
        private PriceRepository priceRepos = null;

        public PriceCategoryController()
        {
            priceRepos = new PriceRepository();
        }

        // GET: Administrator/PriceCategory
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllPriceCategory()
        {
            JsonResult result = new JsonResult();

            List<PriceCategoryDto> lst = priceRepos.GetAll();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPriceCategoryById(long id)
        {
            JsonResult result = new JsonResult();

            PriceCategoryDto data = priceRepos.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdatePriceCategory(PriceCategoryInputDto data)
        {
            return Json(priceRepos.CreateOrUpdatePriceCategory(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePriceCategory(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = priceRepos.DeletePriceCategory(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}