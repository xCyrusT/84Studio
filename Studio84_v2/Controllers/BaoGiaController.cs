using Studio84.Services;
using Studio84.Services.Price.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Controllers
{
    public class BaoGiaController : Controller
    {
        private PriceRepository _priceRepos = null;

        public BaoGiaController()
        {
            _priceRepos = new PriceRepository();
        }

        // GET: BaoGia
        public ActionResult Index()
        {
            ViewBag.LstCategory = _priceRepos.GetAll().Where(x => x.IsActive == true).ToList();

            return View();
        }

        public ActionResult Detail(long id)
        {
            ViewBag.Detail = _priceRepos.GetById(id);

            return View();
        }
    }
}