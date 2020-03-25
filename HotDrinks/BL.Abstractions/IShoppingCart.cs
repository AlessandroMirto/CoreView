using HotDrinks.DAL.Abstractions;
using HotDrinks.Shared;
using System.Collections.Generic;

namespace HotDrinks.BL.Abstractions
{
    public interface IShoppingCart
    {
        decimal Total { get; }
        decimal Discount { get; }
        void AddDrink(IDrink item);
        void RemoveDrink(IDrink item);
        void RemoveItem(ICartItem item);
        void ClearCart();
        IEnumerable<IDrink> GetDrinks();
        IEnumerable<PaymentType> GetAllowedPayments();
        IEnumerable<ICartItem> GetItems();
        void ApplyDiscount(DiscountCodes discountcode);
    }
}
