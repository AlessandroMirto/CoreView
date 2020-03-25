using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using HotDrinks.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotDrinks.Controllers
{
    public class CheckoutController : Controller
    {
        readonly IOrdersRepo ordersRepo;
        readonly IOrderFactory orderFactory;
        readonly IShoppingCart cart;

        public CheckoutController(IOrdersRepo repoinj, IShoppingCart cartinj, IOrderFactory factinj)
        {
            this.ordersRepo = repoinj;
            this.cart = cartinj;
            this.orderFactory = factinj;
        }
        public ActionResult Index()
        {
            var model = new CheckoutViewModel
            {
                Cart = new CartViewModel
                {
                    cartItems = cart.GetItems(),
                    Total = cart.Total
                },
                AllowedPayments = cart.GetAllowedPayments(),
                Discount = cart.Discount
            };
            return View(model);
        }

        public ActionResult ElaborateOrder(CheckoutViewModel model)
        {
            var order = orderFactory.CreateOrderFromCart(cart.GetItems(), 
                cart.Discount, model.SelectedPaymentType, model.Address);
            if (order != null)
            {
                ordersRepo.Insert(order);
                cart.ClearCart();
                return View(order);
            }
            else
            {
                return View("Error");
            }
        }
    }
}