using Newtonsoft.Json;
using OdeToFood.Service.IService;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class MealController : Controller
    {
        private IMealService _mealService { get; }
        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Meals()
        {
            var mealsDeserialized = await _mealService.GetMeal();
            var mealsSerialized = JsonConvert.SerializeObject(mealsDeserialized.hints);
            return Json(mealsSerialized, JsonRequestBehavior.AllowGet);
        }
    }
}
