using Studio84.Services;
using Studio84.Services.Camera.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Areas.Administrator.Controllers
{
    public class CameraCategoryController : Controller
    {
        private CameraCategoryRepository cameraRepos = null;

        public CameraCategoryController()
        {
            cameraRepos = new CameraCategoryRepository();
        }

        //GET: Administrator/CameraCategory
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllCameraCategory()
        {
            JsonResult result = new JsonResult();

            List<CameraCategoryDto> lst = cameraRepos.GetAll();

            result.Data = lst;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCameraCategoryById(long id)
        {
            JsonResult result = new JsonResult();

            CameraCategoryDto data = cameraRepos.GetById(id);

            result.Data = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateOrUpdateCameraCategory(CameraCategoryInputDto data)
        {
            return Json(cameraRepos.CreateOrUpdateCameraCategory(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCameraCategory(long id)
        {
            JsonResult result = new JsonResult();

            result.Data = cameraRepos.DeleteCameraCategory(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
