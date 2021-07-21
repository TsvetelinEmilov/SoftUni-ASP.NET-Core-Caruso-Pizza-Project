namespace CarusoPizza.Data.Models
{
    public class ProductsToppings
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ToppingId { get; set; }

        public Topping Topping { get; set; }


    }
}
