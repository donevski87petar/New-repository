using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using OdeToFood.Domain.Models;
using OdeToFood.Repo.IRepository;
using OdeToFood.Service.Service;
using Xunit;

namespace OdeToFood.UnitTest
{
    [TestClass]
    public class CuisineServiceTests
    {
        private readonly CuisineService _cuisineService;
        private readonly ICuisineRepository _cuisineRepository = Substitute.For<ICuisineRepository>();

        public CuisineServiceTests()
        {
            _cuisineService = new CuisineService(_cuisineRepository);
        }

        [Fact]
        public async Task GetById_ShouldReturnCuisine_WhenCuisineExists()
        {
            //AAA
            var cuisineId = 3;
            var cuisineName = "New Cuisine";
            var cuisine = new Cuisine { CuisineId = cuisineId, CuisineName = cuisineName };

            _cuisineRepository.GetCuisine(cuisineId).Returns(cuisine);

            //Act
            var cuisineById = _cuisineService.GetCuisine(cuisineId);

            //Assert           //expected //actual
            Xunit.Assert.Equal(cuisineId, cuisine.CuisineId);
            Xunit.Assert.Equal(cuisineName, cuisine.CuisineName);
        }


    }
}
