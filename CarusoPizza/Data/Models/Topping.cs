namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;

    public class Topping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductsToppings> Products { get; set; }
    }
}
