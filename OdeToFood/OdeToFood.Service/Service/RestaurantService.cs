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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            return _restaurantRepository.GetRestaurant(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantRepository.GetRestaurants();
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.CreateRestaurant(restaurant);
            return restaurant;
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.DeleteRestaurant(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.UpdateRestaurant(restaurant);
        }
    }
}
