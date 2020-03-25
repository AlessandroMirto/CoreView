using HotDrinks.DAL.Abstractions;
using System.Collections;

namespace HotDrinks.DAL
{
    public class OrderItem : IOrderItem
    {
        public IDrink Drink { get; set; }
        public int Quantity { get; set; }
    }
}