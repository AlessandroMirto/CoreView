using HotDrinks.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.BL.Abstractions
{
    public interface ICartItem
    {
        IDrink Drink { get; set; }
        int Quantity { get; set; }
    }
}
