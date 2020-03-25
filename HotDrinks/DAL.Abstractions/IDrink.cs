using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.DAL.Abstractions
{
    public interface IDrink
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
