using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotDrinks.DAL
{
    public class OrderFactory : IOrderFactory
    {
        static List<string> FactoryLog = new List<string>();
        readonly IOrdersRepo repo;

        public OrderFactory(IOrdersRepo repoinj)
        {
            this.repo = repoinj;
        }

        private void AddToLog(string entry) => FactoryLog.Add(entry);
        public IEnumerable<string> GetLog() => FactoryLog;
        public string GetLastLogEntry() => FactoryLog.LastOrDefault();
        public IOrder CreateOrderFromCart(IEnumerable<ICartItem> items, decimal discount, PaymentType payment, string address)
        {
            var adapter = new CartItemToOrderItemAdapter();
            var OrderItems = items.Select(i => adapter.OrderItem(i)).ToArray();
            if (!IsValid(OrderItems, discount, address))
            {
                return null;
            }
            return new Order(repo.OrderCount, OrderItems, discount, payment, address);

        }

        public IOrder CreateOrder(IEnumerable<IOrderItem> items, decimal discount, PaymentType payment, string address)
        {
            if (!IsValid(items, discount, address))
            {
                return null;
            }

            return new Order(repo.OrderCount, items, discount, payment, address);
        }

        private bool IsValid(IEnumerable<IOrderItem> items, decimal discount, string address)
        {
            if(!items.Any())
            {
                AddToLog($"Cannot create an order with no items to buy");
                return false;
            }
            if (discount < 0 || discount > 1)
            {
                AddToLog($"Invalid discount: {discount}");
                return false;
            }
            if (String.IsNullOrEmpty(address))
            {
                AddToLog("Address not provided");
                return false;
            }

            return true;
        }
    }
}