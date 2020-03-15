using Studio84.Services;
using Studio84.Services.Photo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Controllers
{
    public class ChupAnhController : Controller
    {
        private PhotoCategoryRepository _photoCateRepos = null;
        private PhotoPostRepository _photoPostRepos = null;

        public ChupAnhController()
        {
            _photoCateRepos = new PhotoCategoryRepository();
            _photoPostRepos = new PhotoPostRepository();
        }

        // GET: ChupAnh
        public ActionResult Index()
        {
            ViewBag.LstCategory = GetAllPhotoCategory();

            return View();
        }

        public ActionResult Category(long id)
        {
            PhotoCategoryWithChildDto result = GetAllPhotoCategory().Where(x => x.Id == id).SingleOrDefault();

            ViewBag.Category = result;

            return View();
        }

        public ActionResult Post(long id)
        {
            PhotoPostDto result = _photoPostRepos.GetById(id);

            ViewBag.Detail = result;

            return View();
        }

        private List<PhotoCategoryWithChildDto> GetAllPhotoCategory()
        {
            List<PhotoCategoryWithChildDto> result = new List<PhotoCategoryWithChildDto>();

            result = _photoCateRepos.GetAllPhotoCategoryWithChild().Where(x => x.IsActive == true).ToList();

            return result;
        }
    }
}
