using OdeToFood.Domain.Models;
using OdeToFood.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantService(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
           return _restaurantService.GetRestaurant(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantService.GetRestaurants();
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            _restaurantService.CreateRestaurant(restaurant);
            return restaurant;
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _restaurantService.DeleteRestaurant(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantService.UpdateRestaurant(restaurant);
        }
    }
}
