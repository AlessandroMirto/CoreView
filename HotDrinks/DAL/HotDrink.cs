using HotDrinks.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDrinks.DAL
{
    public class HotDrink : IDrink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}