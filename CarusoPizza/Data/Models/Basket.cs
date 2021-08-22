namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Basket
    {
        public int Id { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SumPrice { get; set; }

        public string UserId { get; init; }

        public int OrderId { get; set; }

        public Order Order { get; init; }

        public IEnumerable<OrderProduct> Products { get; set; } = new List<OrderProduct>();

    }
}
