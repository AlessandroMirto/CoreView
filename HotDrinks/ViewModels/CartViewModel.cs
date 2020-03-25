using HotDrinks.BL.Abstractions;
using HotDrinks.DAL.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace HotDrinks.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<ICartItem> cartItems { get; set; }
        public decimal Total { get; set; }
    }
}