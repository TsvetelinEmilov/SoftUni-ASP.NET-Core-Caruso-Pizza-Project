namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int PizzaSizeId { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Comment { get; set; }

        public string UserId { get; init; }

        public bool IsOrdered { get; set; }

        public List<OrderProductTopping> OrderProductToppings { get; set; } = new List<OrderProductTopping>();

    }
}
