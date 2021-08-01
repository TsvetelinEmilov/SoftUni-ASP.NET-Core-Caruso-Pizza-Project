namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? PizzaSizeId { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Comment { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public IEnumerable<OrderProductsToppings> Toppings { get; set; } = new List<OrderProductsToppings>();

    }
}
