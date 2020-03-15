using Studio84.Services;
using Studio84.Services.Camera.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class CameraPostController : Controller
    {
        private CameraCategoryRepository cameraCateRepos = null;
        private CameraPostRepository cameraRepos = null;

        public CameraPostController()
        {
            cameraCateRepos = new CameraCategoryRepository();
            cameraRepos = new CameraPostRepository();
        }

        // GET: Administrator/CameraPost
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllCameraCategory()
        {
            JsonResult result = new JsonResult();

            List<CameraCategoryDto> lstCate = cameraCateRepos.GetAll().Where(x => x.IsActive == true).ToList();

            result.Data = lstCate;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCameraPost()
        {
            JsonResult result = new JsonResult();

            List<CameraPostDto> lst = cameraRepos.GetAllCameraPost();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCameraPostById(long id)
        {
            JsonResult result = new JsonResult();

            CameraPostDto data = cameraRepos.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdateCameraPost(CameraPostInputDto data)
        {
            return Json(cameraRepos.CreateOrUpdateCameraPost(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCameraPost(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = cameraRepos.DeleteCameraPost(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}