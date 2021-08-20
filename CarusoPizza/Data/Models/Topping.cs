namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants.Topping;

    public class Topping
    {
        public int Id { get; init; }

        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; init; }

        public bool IsOrdered { get; set; }

        public IEnumerable<OrderProductsToppings> OrderProducts { get; set; }
    }
}
