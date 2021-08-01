namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;

    public class PizzaSize
    {
        public int Id { get; init; }
         
        public string Size { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; init; } = new List<OrderProduct>();
    }
}