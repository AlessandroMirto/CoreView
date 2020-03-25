using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotDrinks.BL
{
    public class ShoppingCart : IShoppingCart
    {
        static List<ICartItem> cart = new List<ICartItem>();
        public decimal Total => cart.Select(i => i.Drink.Price * i.Quantity * (1 - Discount)).Sum();
        public decimal Discount { get; private set; } = 0;
        public void AddDrink(IDrink drink)
        {
            if (ContainsDrink(drink))
            {
                GetItem(drink.Id).Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Drink = drink, Quantity = 1 });
            }
        }
        public void ApplyDiscount(DiscountCodes discountcode)
        {
            switch (discountcode)
            {
                case DiscountCodes.DISCOUNT20:
                    Discount = 0.2M;
                    break;
                case DiscountCodes.DISCOUNT50:
                    Discount = 0.5M;
                    break;
                case DiscountCodes.ALLFREE:
                    Discount = 1;
                    break;
                default:
                    Discount = 0;
                    break;
            }
        }
        public IEnumerable<PaymentType> GetAllowedPayments()
        {
            List<PaymentType> paymentTypes = new List<PaymentType>() { PaymentType.CreditCard };
            if (Total <= 10.0M)
                paymentTypes.Add(PaymentType.Cash);
            return paymentTypes;

        }
        public IEnumerable<IDrink> GetDrinks() => cart.Select(i => i.Drink);
        public IEnumerable<ICartItem> GetItems() => cart;
        public void RemoveDrink(IDrink item)
        {
            if (ContainsDrink(item) && GetItem(item.Id).Quantity == 1)
            {
                cart.Remove(GetItem(item.Id));
            }
            else if (ContainsDrink(item))
            {
                GetItem(item.Id).Quantity--;
            }
            else
            {
                throw new ArgumentException("Invalid Drink item", nameof(item));
            }
        }
        public void RemoveItem(ICartItem item)
        {
            if (ContainsDrink(item.Drink))
            {
                cart.Remove(GetItem(item.Drink.Id));
            }
            else
            {
                throw new ArgumentException("Invalid Cart item", nameof(item));
            }
        }
        public void ClearCart() => cart.Clear();

        private bool ContainsDrink(IDrink drink) => cart.Any(i => i.Drink.Id == drink.Id);
        private ICartItem GetItem(int id) => cart.SingleOrDefault(i => i.Drink.Id == id);
    }
}