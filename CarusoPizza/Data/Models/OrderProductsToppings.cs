namespace CarusoPizza.Data.Models
{
    public class OrderProductsToppings
    {
        public int Id { get; set; }

        public int OrderProductId { get; set; }

        public OrderProduct Product { get; set; }

        public int ToppingId { get; set; }

        public Topping Topping { get; set; }


    }
}
