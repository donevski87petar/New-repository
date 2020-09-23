using OdeToFood.Domain.Models;
using OdeToFood.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemService(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            return _menuItemService.GetMenuItem(menuItemId);
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return _menuItemService.GetMenuItems();
        }

        public MenuItem CreateMenuItem(MenuItem menuItem)
        {
            _menuItemService.CreateMenuItem(menuItem);
            return menuItem;
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            _menuItemService.DeleteMenuItem(menuItem);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            _menuItemService.UpdateMenuItem(menuItem);
        }
    }
}
