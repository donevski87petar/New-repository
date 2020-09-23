using OdeToFood.Domain.Models;
using OdeToFood.Repo.IRepository;
using OdeToFood.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Service.Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            return _menuItemRepository.GetMenuItem(menuItemId);
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return _menuItemRepository.GetMenuItems();
        }

        public MenuItem CreateMenuItem(MenuItem menuItem)
        {
            _menuItemRepository.CreateMenuItem(menuItem);
            return menuItem;
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            _menuItemRepository.DeleteMenuItem(menuItem);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            _menuItemRepository.UpdateMenuItem(menuItem);
        }
    }
}
