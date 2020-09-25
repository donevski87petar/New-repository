using OdeToFood.Domain.Models;
using OdeToFood.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OdeToFood.Web.API
{
    //[Route("api/[controller]")]
    public class CuisineController : ApiController
    {

        private readonly ICuisineService _cuisineService;

        public CuisineController()
        {

        }
        public CuisineController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }

        // GET: api/Cuisine
        [HttpGet]
        public IHttpActionResult GetCuisines()
        {
            var cuisines = _cuisineService.GetCuisines();
            if (cuisines == null)
            {
                return NotFound();
            }
            return Ok(cuisines);
        }








    }
}
