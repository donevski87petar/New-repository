using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OdeToFood.Service.IService
{
    public interface IMealService
    {
        Task<Meal> GetMeal();
    }
}
