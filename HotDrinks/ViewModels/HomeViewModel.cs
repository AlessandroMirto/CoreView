using HotDrinks.BL.Abstractions;
using System.Collections.Generic;

namespace HotDrinks.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DrinkViewModel> Drinks { get; set; }
        public CartViewModel Cart { get; set; }
    }
}