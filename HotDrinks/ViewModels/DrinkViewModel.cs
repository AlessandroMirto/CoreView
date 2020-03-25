using System.Collections.Generic;
using System.Linq;

namespace HotDrinks.ViewModels
{
    public class DrinkViewModel
    {
        static Dictionary<string, string> ImgSources = new Dictionary<string, string>()
        {
            { "Italian", "Content/img/espresso.png"},
            { "American", "Content/img/americano.png"},
            { "Chocolate", "Content/img/chocolate.png"},
            { "Tea", "Content/img/tea.png"},
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgSource => ImgSources.Where(s => Name.Contains(s.Key)).FirstOrDefault().Value
            ?? "Content/img/product_image_not_available.png";

    }
}