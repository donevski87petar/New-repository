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
using OdeToFood.Service.IService;

namespace OdeToFood.Web.Controllers
{
    public class MenuItemsController : Controller
    {
        private IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        // GET: MenuItems
        public ActionResult Index()
        {
            var menuItems = _menuItemService.GetMenuItems();
            return View(menuItems);
        }

        // GET: MenuItems/Details/5
        public ActionResult Details(int id)
        {
            MenuItem menuItem = _menuItemService.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        
    }
}
