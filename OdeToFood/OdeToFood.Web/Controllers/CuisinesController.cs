using OdeToFood.Domain.Models;
using OdeToFood.Service.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class CuisinesController : Controller
    {
        private ICuisineService _cuisineService;
        public CuisinesController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }

        public ActionResult Index()
        {
            var model = _cuisineService.GetCuisines();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _cuisineService.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


    }
}