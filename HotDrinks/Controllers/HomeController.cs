using HotDrinks.BL;
using HotDrinks.BL.Abstractions;
using HotDrinks.DAL;
using HotDrinks.DAL.Abstractions;
using HotDrinks.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotDrinks.Controllers
{
    public class HomeController : Controller
    {
        readonly IDrinksRepo hotDrinksRepo;
        readonly IShoppingCart shoppingcart; 
        public HomeController(IDrinksRepo repoinj, IShoppingCart cartinj)
        {
            this.hotDrinksRepo = repoinj;
            this.shoppingcart = cartinj;
        }
        public ActionResult Index()
        {
            var viewmodelDrinks = new List<DrinkViewModel>();
            foreach (var drink in hotDrinksRepo.GetAll())
            {
                viewmodelDrinks.Add(new DrinkViewModel
                {
                    Id = drink.Id,
                    Name = drink.Name,
                    Price = drink.Price
                });
            }

            var viewmodelCart = new CartViewModel
            {
                cartItems = shoppingcart.GetItems(),
                Total = shoppingcart.Total
            };

            var model = new HomeViewModel()
            {
                Drinks = viewmodelDrinks,
                Cart = viewmodelCart
            };
            return View(model);
        }
    }
}