using HotDrinks.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.DAL.Abstractions
{
    public interface IOrder
    {
        int Id { get; set; }
        decimal AppliedDiscount { get; set; }
        IEnumerable<IOrderItem> Items { get; set; }
        PaymentType Payment { get; set; }
        string Address { get; set; }
    }
}
