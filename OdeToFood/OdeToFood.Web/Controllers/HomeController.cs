using OdeToFood.Domain.Models;
using OdeToFood.Domain.ViewModels;
using OdeToFood.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICuisineService _cuisineService;
        private IRestaurantService _restaurantService;
        private IMenuItemService _menuItemService;

        public HomeController(ICuisineService cuisineService,
                              IRestaurantService restaurantService,
                              IMenuItemService menuItemService)
        {
            _cuisineService = cuisineService;
            _restaurantService = restaurantService;
            _menuItemService = menuItemService;
        }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Cuisines = _cuisineService.GetCuisines();
            homeViewModel.Restaurants = _restaurantService.GetRestaurants();
            homeViewModel.MenuItems = _menuItemService.GetMenuItems();
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}