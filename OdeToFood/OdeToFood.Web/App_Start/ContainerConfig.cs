using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data;
using OdeToFood.Repo.IRepository;
using OdeToFood.Service.IService;
using OdeToFood.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            builder.RegisterType<CuisineRepository>().As<ICuisineRepository>().InstancePerRequest();
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>().InstancePerRequest();
            builder.RegisterType<MenuItemRepository>().As<IMenuItemRepository>().InstancePerRequest();

            builder.RegisterType<CuisineService>().As<ICuisineService>().InstancePerRequest();
            builder.RegisterType<RestaurantService>().As<IRestaurantService>().InstancePerRequest();
            builder.RegisterType<MenuItemService>().As<IMenuItemService>().InstancePerRequest();
            builder.RegisterType<MealService>().As<IMealService>().InstancePerRequest();

            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();



            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}