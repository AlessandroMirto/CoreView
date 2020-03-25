using HotDrinks.BL;
using HotDrinks.BL.Abstractions;
using HotDrinks.DAL;
using HotDrinks.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Tests.BL
{
    [TestClass]
    public class ShoppingCartTests
    {
        HotDrink PricyDrink = new HotDrink() { Id = 99, Name = "PricyDrink", Price = 10.1M };
        HotDrink CheapDrink = new HotDrink() { Id = 999, Name = "CheapDrink", Price = 1.0M };

        [TestMethod]
        public void TestAllowedPayment_OnlyCC()
        {
            //Arrange
            var cart = new ShoppingCart();
            //Act
            cart.ClearCart();
            cart.AddDrink(PricyDrink);
            //Assert
            Assert.IsFalse(cart.GetAllowedPayments().Contains(PaymentType.Cash));
            Assert.IsTrue(cart.GetAllowedPayments().Contains(PaymentType.CreditCard));
        }

        [TestMethod]
        public void TestAllowedPayment_IncludesCash()
        {
            //Arrange
            var cart = new ShoppingCart();
            //Act
            cart.ClearCart();
            cart.AddDrink(CheapDrink);
            //Assert
            Assert.IsTrue(cart.GetAllowedPayments().Contains(PaymentType.Cash));
            Assert.IsTrue(cart.GetAllowedPayments().Contains(PaymentType.CreditCard));
        }

        [TestMethod]
        public void Discount20Applyed()
        {
            //Arrange
            var cart = new ShoppingCart();
            var total = 10.1M * (1 - 0.2M);
            //Act
            cart.ClearCart();
            cart.AddDrink(PricyDrink);
            cart.ApplyDiscount(DiscountCodes.DISCOUNT20);
            //Assert
            Assert.AreEqual(cart.GetTotal(), total);
            Assert.AreEqual(cart.GetDiscount(), 0.2M);
        }

        [TestMethod]
        public void Discount50Applyed()
        {
            //Arrange
            var cart = new ShoppingCart();
            var total = 10.1M * (1 - 0.5M);
            //Act
            cart.ClearCart();
            cart.AddDrink(PricyDrink);
            cart.ApplyDiscount(DiscountCodes.DISCOUNT50);
            //Assert
            Assert.AreEqual(cart.GetTotal(), total);
            Assert.AreEqual(cart.GetDiscount(), 0.5M);
        }

        [TestMethod]
        public void DiscountALLFREEApplyed()
        {
            //Arrange
            var cart = new ShoppingCart();
            var total = 0M;
            //Act
            cart.ClearCart();
            cart.AddDrink(PricyDrink);
            cart.ApplyDiscount(DiscountCodes.ALLFREE);
            //Assert
            Assert.AreEqual(cart.GetTotal(), total);
            Assert.AreEqual(cart.GetDiscount(), 1M);
        }

        [TestMethod]
        public void CheckTotal()
        {
            //Arrange
            var cart = new ShoppingCart();
            decimal total = 12.1M;
            //Act
            cart.ClearCart();
            cart.AddDrink(PricyDrink);
            cart.AddDrink(CheapDrink);
            cart.AddDrink(CheapDrink);
            //Assert
            Assert.AreEqual(cart.GetTotal(), total);
        }

        [TestMethod]
        public void AddToCartDoesNotDuplicateCartItems()
        {
            //Arrange
            var cart = new ShoppingCart();
            //Act
            cart.ClearCart();
            cart.AddDrink(PricyDrink);
            cart.AddDrink(PricyDrink);
            //Assert
            Assert.AreEqual(cart.GetItems().Count(), 1);
            Assert.AreEqual(cart.GetItems().Select(i => i.Quantity).Sum(), 2);
        }

    }
}
