namespace CarusoPizza.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProductTopping
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; init; }

        public bool IsOrdered { get; set; }

        public int? OrderProductId { get; set; }

        public OrderProduct OrderProduct { get; set; }
    }
}
