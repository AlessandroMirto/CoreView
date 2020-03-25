using Autofac;
using Autofac.Integration.Mvc;
using HotDrinks.BL;
using HotDrinks.BL.Abstractions;
using HotDrinks.DAL;
using HotDrinks.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HotDrinks.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterType<ShoppingCart>()
                    .As<IShoppingCart>()
                    .SingleInstance();

            builder.RegisterType<HotDrinksRepo>()
                .As<IDrinksRepo>()
                .SingleInstance();

            builder.RegisterType<OrdersRepo>()
                .As<IOrdersRepo>()
                .SingleInstance();

            builder.RegisterType<OrderFactory>()
                .As<IOrderFactory>()
                .SingleInstance();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}