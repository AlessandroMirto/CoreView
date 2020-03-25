using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDrinks.DAL
{
    public class Order : IOrder
    {
        public Order(int id, IEnumerable<IOrderItem> items, decimal discount, PaymentType payment, string address)
        {
            this.Id = id;
            this.Items = items;
            this.AppliedDiscount = discount;
            this.Payment = payment;
            this.Address = address;
        }
        public int Id { get; set; }
        public IEnumerable<IOrderItem> Items { get; set; }
        public decimal AppliedDiscount { get; set; }
        public PaymentType Payment { get; set; }
        public string Address { get; set; }
    }
}