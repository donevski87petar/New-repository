using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Service.IService
{
    public interface IRestaurantService
    {
        Restaurant CreateRestaurant(Restaurant restaurant);
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int restaurantId);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);
    }

}
