using System.Collections.Generic;

namespace CarusoPizza.Models.Product
{
    public class ProductsListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PizzaSize { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<ProductToppingViewModel> Toppings { get; set; }

        public string Description { get; set; }
    }
}
