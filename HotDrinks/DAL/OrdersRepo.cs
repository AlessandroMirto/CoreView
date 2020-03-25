using HotDrinks.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDrinks.DAL
{
    public class OrdersRepo : IOrdersRepo
    {
        static List<IOrder> orders = new List<IOrder>();

        public int OrderCount => orders.Count();

        public void Delete(int id) => orders.Remove(Get(id));
        public IOrder Get(int id) => orders.SingleOrDefault(o => o.Id == id);
        public IEnumerable<IOrder> GetAll() => orders;
        public void Insert(IOrder obj) => orders.Add(obj);
    }
}