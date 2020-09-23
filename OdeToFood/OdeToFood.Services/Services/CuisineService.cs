using OdeToFood.Domain.Models;
using OdeToFood.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Services
{
    public class CuisineService : ICuisineService
    {
        private readonly ICuisineService _cuisineService;
        public CuisineService(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }

        public Cuisine GetCuisine(int cuisineId)
        {
            return _cuisineService.GetCuisine(cuisineId);
        }

        public IEnumerable<Cuisine> GetCuisines()
        {
            return _cuisineService.GetCuisines();
        }

        public Cuisine CreateCuisine(Cuisine cuisine)
        {
            _cuisineService.CreateCuisine(cuisine);
            return cuisine;
        }

        public void DeleteCuisine(Cuisine cuisine)
        {
            _cuisineService.DeleteCuisine(cuisine);
        }

        public void UpdateCuisine(Cuisine cuisine)
        {
            _cuisineService.UpdateCuisine(cuisine);
        }
    }
}
