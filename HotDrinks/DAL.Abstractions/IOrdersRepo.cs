using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.DAL.Abstractions
{
    public interface IOrdersRepo
    {
        int OrderCount { get; }
        IEnumerable<IOrder> GetAll();
        IOrder Get(int id);
        void Insert(IOrder obj);
        void Delete(int id);
    }
}
