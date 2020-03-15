using Studio84.Services;
using Studio84.Services.Camera.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Controllers
{
    public class QuayPhimController : Controller
    {
        private CameraCategoryRepository _cameraCateRepos = null;
        private CameraPostRepository _cameraPostRepos = null;

        public QuayPhimController()
        {
            _cameraCateRepos = new CameraCategoryRepository();
            _cameraPostRepos = new CameraPostRepository();
        }

        // GET: QuayPhim
        public ActionResult Index()
        {
            ViewBag.LstCategory = GetAllCameraCategory();

            return View();
        }

        public ActionResult Category(long id)
        {
            CameraCategoryWithChildDto result = GetAllCameraCategory().Where(x => x.Id == id).SingleOrDefault();

            ViewBag.Category = result;

            return View();
        }

        private List<CameraCategoryWithChildDto> GetAllCameraCategory()
        {
            List<CameraCategoryWithChildDto> result = new List<CameraCategoryWithChildDto>();

            result = _cameraCateRepos.GetAllCameraCategoryWithChild().Where(x => x.IsActive == true).ToList();

            return result;
        }
    }
}
