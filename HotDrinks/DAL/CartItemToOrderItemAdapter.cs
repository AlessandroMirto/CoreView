using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDrinks.DAL
{
    public class CartItemToOrderItemAdapter
    {
        public IOrderItem OrderItem(ICartItem cartItem)
        {
            return new OrderItem
            {
                Drink = cartItem.Drink,
                Quantity = cartItem.Quantity
            };
        }
    }
}