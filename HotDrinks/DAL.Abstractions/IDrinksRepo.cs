using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.DAL.Abstractions
{
    public interface IDrinksRepo
    {
        IEnumerable<IDrink> GetAll();
        IDrink Get(int id);
    }
}
