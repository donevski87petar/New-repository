using OdeToFood.Domain.Models;
using OdeToFood.Domain.ViewModels;
using OdeToFood.Service.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Constructor
        private readonly ICuisineService _cuisineService;
        private readonly IRestaurantService _restaurantService;
        private readonly IMenuItemService _menuItemService;
        public AdminController(ICuisineService cuisineService,
                               IRestaurantService restaurantService,
                               IMenuItemService menuItemService)
        {
            _cuisineService = cuisineService;
            _restaurantService = restaurantService;
            _menuItemService = menuItemService;
        }
        #endregion Constructor

        #region Cuisine

        public ActionResult IndexCuisine()
        {
            var model = _cuisineService.GetCuisines();
            return View(model);
        }

        public ActionResult DetailsCuisine(int id)
        {
            var model = _cuisineService.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditCuisine(int id)
        {
            var model = _cuisineService.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                if(cuisine.ImageFile != null)
                {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(cuisine.ImageFile.FileName);
                    string extension = Path.GetExtension(cuisine.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    cuisine.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    cuisine.ImageFile.SaveAs(fileName);
                }

                _cuisineService.UpdateCuisine(cuisine);
                ModelState.Clear();
                return RedirectToAction("DetailsCuisine", new { id = cuisine.CuisineId });
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult CreateCuisine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                if(cuisine.ImageFile != null)
                {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(cuisine.ImageFile.FileName);
                    string extension = Path.GetExtension(cuisine.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    cuisine.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    cuisine.ImageFile.SaveAs(fileName);
                }

                _cuisineService.CreateCuisine(cuisine);
                ModelState.Clear();
                return RedirectToAction("DetailsCuisine", new { id = cuisine.CuisineId });
            }
            return View(cuisine);
        }

        [HttpGet]
        public ActionResult DeleteCuisine(int id)
        {
            var model = _cuisineService.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCuisine(int id, Cuisine c)
        {
            var cuisine = _cuisineService.GetCuisine(id);
            _cuisineService.DeleteCuisine(cuisine);
            return RedirectToAction("IndexCuisine");
        }

        #endregion Cuisine


        #region Restaurant
        public ActionResult IndexRestaurant()
        {
            var model = _restaurantService.GetRestaurants();
            return View(model);
        }

        public ActionResult DetailsRestaurant(int id)
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

        public ActionResult CreateRestaurant()
        {
            var cuisines = _cuisineService.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                if(restaurant.ImageFile != null)
                {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(restaurant.ImageFile.FileName);
                    string extension = Path.GetExtension(restaurant.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    restaurant.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    restaurant.ImageFile.SaveAs(fileName);
                }
                _restaurantService.CreateRestaurant(restaurant);

                ModelState.Clear();

                return RedirectToAction("DetailsRestaurant", "Admin", new { id = restaurant.RestaurantId });
            }

            var cuisines = _cuisineService.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        public ActionResult EditRestaurant(int id)
        {
            Restaurant restaurant = _restaurantService.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            var cuisines = _cuisineService.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                if(restaurant.ImageFile != null)
                {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(restaurant.ImageFile.FileName);
                    string extension = Path.GetExtension(restaurant.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    restaurant.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    restaurant.ImageFile.SaveAs(fileName);
                }
                _restaurantService.UpdateRestaurant(restaurant);

                ModelState.Clear();

                return RedirectToAction("Details", "DetailsRestaurant", new { id = restaurant.RestaurantId });
            }
            var cuisines = _cuisineService.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        public ActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = _restaurantService.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [HttpPost, ActionName("DeleteRestaurant")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = _restaurantService.GetRestaurant(id);
            _restaurantService.DeleteRestaurant(restaurant);
            return RedirectToAction("IndexRestaurant");
        }

        #endregion Restaurant


        #region Menu Item

        public ActionResult DetailsMenuItem(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItem(id);
            if(menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        public ActionResult CreateMenuItem()
        {
            var cuisines = _cuisineService.GetCuisines();
            var restaurants = _restaurantService.GetRestaurants();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName");
            ViewBag.RestaurantId = new SelectList(restaurants, "RestaurantId", "RestaurantName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMenuItem(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                if(menuItem.ImageFile != null)
                {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(menuItem.ImageFile.FileName);
                    string extension = Path.GetExtension(menuItem.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    menuItem.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    menuItem.ImageFile.SaveAs(fileName);
                }
                _menuItemService.CreateMenuItem(menuItem);
                ModelState.Clear();
                return RedirectToAction("Details", "MenuItems", new { id = menuItem.MenuItemId });
            }
            var cuisines = _cuisineService.GetCuisines();
            var restaurants = _restaurantService.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(restaurants, "RestaurantId", "RestaurantName", menuItem.RestaurantId);

            return View(menuItem);
        }

        public ActionResult EditMenuItem(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }

            var cuisines = _cuisineService.GetCuisines();
            var subcategories = _restaurantService.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(subcategories, "RestaurantId", "RestaurantName", menuItem.RestaurantId);

            return View(menuItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMenuItem(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                if(menuItem.ImageFile != null)
                {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(menuItem.ImageFile.FileName);
                    string extension = Path.GetExtension(menuItem.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    menuItem.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    menuItem.ImageFile.SaveAs(fileName);

                }
                _menuItemService.UpdateMenuItem(menuItem);
                ModelState.Clear();
                return RedirectToAction("Details", "MenuItems", new { id = menuItem.MenuItemId });
            }

            var cuisines = _cuisineService.GetCuisines();
            var subcategories = _restaurantService.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(subcategories, "RestaurantId", "RestaurantName", menuItem.RestaurantId);

            return View(menuItem);
        }


        public ActionResult DeleteMenuItem(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        [HttpPost, ActionName("DeleteMenuItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMenuItemConfirmed(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItem(id);
            _menuItemService.DeleteMenuItem(menuItem);
            return RedirectToAction("Index");
        }

        #endregion
    }
}