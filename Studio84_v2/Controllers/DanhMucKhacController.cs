using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Controllers
{
    public class DanhMucKhacController : Controller
    {
        // GET: DanhMucKhac
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(long id)
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            return View();
        }
    }
}
