using HotDrinks.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace HotDrinks.DAL
{
    public class HotDrinksRepo : IDrinksRepo
    {
        static HotDrink[] hotDrinks= new HotDrink[]
            {
                new HotDrink{ Id = 0, Name = "Italian Coffee", Price = 1.0M },
                new HotDrink{ Id = 1, Name = "American Coffee", Price = 2.0M },
                new HotDrink{ Id = 2, Name = "Tea", Price = 1.5M },
                new HotDrink{ Id = 3, Name = "Chocolate", Price = 2.5M },
            };

        public IDrink Get(int id) => hotDrinks.SingleOrDefault(d => d.Id == id);

        public IEnumerable<IDrink> GetAll() => hotDrinks;

    }
}