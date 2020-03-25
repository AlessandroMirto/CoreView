using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;

namespace HotDrinks.BL
{
    public class CartItem : ICartItem
    {
        public IDrink Drink { get; set; }
        public int Quantity { get; set; }
    }
}