using Studio84.Services;
using Studio84.Services.Camera.Dto;
using Studio84.Services.OtherCategory.Dto;
using Studio84.Services.Photo.Dto;
using Studio84.Services.Price.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio84_v2.Controllers
{
    public class HomeController : Controller
    {
        private PhotoCategoryRepository _photoCateRepos = null;
        private CameraCategoryRepository _cameraCateRepos = null;
        private OtherCategoryRepository _otherCateRepos = null;
        private PriceRepository _priceRepos = null;

        public HomeController()
        {
            _photoCateRepos = new PhotoCategoryRepository();
            _cameraCateRepos = new CameraCategoryRepository();
            _otherCateRepos = new OtherCategoryRepository();
            _priceRepos = new PriceRepository();
        }

        public ActionResult Index()
        {
            ViewBag.PhotoLst = GetAllPhotoCategory();
            ViewBag.CameraLst = GetAllCameraCategory();
            //ViewBag.OtherLst = GetAllOtherCategory();
            ViewBag.PriceLst = GetAllPriceCategory();

            return View();
        }

        private List<PhotoCategoryDto> GetAllPhotoCategory()
        {
            List<PhotoCategoryDto> result = new List<PhotoCategoryDto>();

            result = _photoCateRepos.GetAll().Where(x => x.IsActive == true).ToList();

            return result;
        }

        private List<CameraCategoryDto> GetAllCameraCategory()
        {
            List<CameraCategoryDto> result = new List<CameraCategoryDto>();

            result = _cameraCateRepos.GetAll().Where(x => x.IsActive == true).ToList();

            return result;
        }

        //private List<OtherCategoryDto> GetAllOtherCategory()
        //{
        //    List<OtherCategoryDto> result = new List<OtherCategoryDto>();

        //    result = _otherCateRepos.GetAll().Where(x => x.IsActive == true && x.IsRoot == true).ToList();

        //    return result;
        //}

        private List<PriceCategoryDto> GetAllPriceCategory()
        {
            List<PriceCategoryDto> result = new List<PriceCategoryDto>();

            result = _priceRepos.GetAll().Where(x => x.IsActive == true).ToList();

            return result;
        }
    }
}
