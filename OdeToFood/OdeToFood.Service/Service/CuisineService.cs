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
    public class CuisineService : ICuisineService
    {
        private readonly ICuisineRepository _cuisineRepository;
        public CuisineService(ICuisineRepository cuisineRepository)
        {
            _cuisineRepository = cuisineRepository;
        }

        public CuisineService()
        {
        }

        public Cuisine GetCuisine(int cuisineId)
        {
            return _cuisineRepository.GetCuisine(cuisineId);
        }

        public IEnumerable<Cuisine> GetCuisines()
        {
            return _cuisineRepository.GetCuisines();
        }

        public Cuisine CreateCuisine(Cuisine cuisine)
        {
            _cuisineRepository.CreateCuisine(cuisine);
            return cuisine;
        }

        public void DeleteCuisine(Cuisine cuisine)
        {
            _cuisineRepository.DeleteCuisine(cuisine);
        }

        public void UpdateCuisine(Cuisine cuisine)
        {
            _cuisineRepository.UpdateCuisine(cuisine);
        }
    }
}
