using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data;
using OdeToFood.Domain.Models;
using OdeToFood.Domain.ViewModels;
using OdeToFood.Service.IService;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ICuisineService _cuisineService;
        private readonly IMenuItemService _menuItemService;

        public RestaurantsController(IRestaurantService restaurantService,
                                       ICuisineService cuisineService,
                                       IMenuItemService menuItemService)
        {
            _restaurantService = restaurantService;
            _cuisineService = cuisineService;
            _menuItemService = menuItemService;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var restaurants = _restaurantService.GetRestaurants();
            return View(restaurants);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            Restaurant restaurant = _restaurantService.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            IEnumerable<MenuItem> menuItems = _menuItemService.GetMenuItems()
                                                   .Where(r => r.RestaurantId == id);

            RestaurantDetailsViewModel restaurantDetailsVM = new RestaurantDetailsViewModel();
            restaurantDetailsVM.Restaurant = restaurant;
            restaurantDetailsVM.MenuItems = menuItems;
            
            return View(restaurantDetailsVM);
        }

        
    }
}
