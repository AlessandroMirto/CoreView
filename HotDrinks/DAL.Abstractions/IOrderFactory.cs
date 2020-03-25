using HotDrinks.BL.Abstractions;
using HotDrinks.Shared;
using System.Collections.Generic;

namespace HotDrinks.DAL.Abstractions
{
    public interface IOrderFactory
    {
        IOrder CreateOrder(IEnumerable<IOrderItem> items, 
            decimal discount, 
            PaymentType payment,
            string address);

        IOrder CreateOrderFromCart(IEnumerable<ICartItem> items,
            decimal discount,
            PaymentType payment,
            string address); 
    }
}