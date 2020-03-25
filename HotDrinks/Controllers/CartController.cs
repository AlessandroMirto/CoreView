using HotDrinks.BL;
using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using HotDrinks.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotDrinks.Controllers
{
    public class CartController : Controller
    {
        readonly IShoppingCart shoppingcart;
        readonly IDrinksRepo drinksRepo;

        public CartController(IShoppingCart cartinj, IDrinksRepo drinkinj)
        {
            this.shoppingcart = cartinj;
            this.drinksRepo = drinkinj;
        }

        public PartialViewResult AddToCart(int id)
        {
            shoppingcart.AddDrink(drinksRepo.Get(id));
            var viewmodelCart = new CartViewModel
            {
                cartItems = shoppingcart.GetItems(),
                Total = shoppingcart.Total
            };

            return PartialView("Cart", viewmodelCart);

        }

        public PartialViewResult RemoveFromCart(int id)
        {
            shoppingcart.RemoveDrink(drinksRepo.Get(id));
            var viewmodelCart = new CartViewModel
            {
                cartItems = shoppingcart.GetItems(),
                Total = shoppingcart.Total
            };
            return PartialView("Cart", viewmodelCart);
        }

        public PartialViewResult DeleteItem(int id)
        {
            shoppingcart.RemoveItem(shoppingcart.GetItems().Single(i => i.Drink.Id == id));
            var viewmodelCart = new CartViewModel
            {
                cartItems = shoppingcart.GetItems(),
                Total = shoppingcart.Total
            };

            return PartialView("Cart", viewmodelCart);

        }

        public ActionResult ApplyDiscount(string discountcode)
        {
            DiscountCodes code;
            if (Enum.TryParse<DiscountCodes>(discountcode, out code))
            {
                shoppingcart.ApplyDiscount(code);
            }

            return RedirectToAction("Index", "Checkout");
        }
    }
}