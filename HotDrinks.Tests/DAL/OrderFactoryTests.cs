using HotDrinks.BL;
using HotDrinks.DAL;
using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace HotDrinks.Tests.DAL
{
    [TestClass]
    public class OrderFactoryTests
    {
        Mock<IOrdersRepo> mockrepo;
        decimal discount = 0.5M;
        string address = "testAddress";
        HotDrink PricyDrink = new HotDrink() { Id = 99, Name = "PricyDrink", Price = 10.1M };

        [TestMethod]
        public void TestCreateFromCart()
        {
            //Arrange
            mockrepo = new Mock<IOrdersRepo>();
            mockrepo.SetupGet(r => r.OrderCount).Returns(1);
            var CartItems = new CartItem[]
            {
                new CartItem() { Drink = PricyDrink, Quantity = 100 }
            };
            IOrderItem[] OrderItems = new OrderItem[] 
            {
                new OrderItem() { Drink = PricyDrink, Quantity = 100 }
            };
            var factory = new OrderFactory(mockrepo.Object);
            Order expected = new Order(1, OrderItems, discount, PaymentType.CreditCard, address);
            var expectedDrinkID = expected.Items.Select(i => i.Drink.Id).Single();
            //Act
            var actual = factory.CreateOrderFromCart(CartItems, discount, PaymentType.CreditCard, address);
            var actualDrinkID = actual.Items.Select(i => i.Drink.Id).Single();
            //Assert
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.AppliedDiscount, expected.AppliedDiscount);
            Assert.AreEqual(actual.Payment, expected.Payment);
            Assert.AreEqual(actual.Address, expected.Address);
            Assert.AreEqual(actualDrinkID, expectedDrinkID);
            mockrepo.Verify(r => r.OrderCount, Times.Once);
        }

        [TestMethod]
        public void TestCreateFromCart_WithInvalid()
        {
            //Arrange
            mockrepo = new Mock<IOrdersRepo>();
            mockrepo.SetupGet(r => r.OrderCount).Returns(0);
            var CartItemsInvalid = new List<CartItem>();
            var CartItemsValid = new CartItem[]
            {
                new CartItem() { Drink = PricyDrink, Quantity = 100 }
            };
            var DiscountTooLow = -0.1M;
            var DiscountTooHight = 1.1M;
            var EmptyAddress = string.Empty;
            var factory = new OrderFactory(mockrepo.Object);
            //Act
            var actualInvalidItems = factory.CreateOrderFromCart(CartItemsInvalid, discount, PaymentType.CreditCard, address);
            var actualDiscountTooLow = factory.CreateOrderFromCart(CartItemsValid, DiscountTooLow, PaymentType.CreditCard, address);
            var actualDiscountTooHigh = factory.CreateOrderFromCart(CartItemsValid, DiscountTooHight, PaymentType.CreditCard, address);
            var actualInvalidAddress = factory.CreateOrderFromCart(CartItemsValid, discount, PaymentType.CreditCard, EmptyAddress);
            //Assert
            Assert.IsNull(actualInvalidItems);
            Assert.IsNull(actualDiscountTooLow);
            Assert.IsNull(actualDiscountTooHigh);
            Assert.IsNull(actualInvalidAddress);
        }
    }
}
