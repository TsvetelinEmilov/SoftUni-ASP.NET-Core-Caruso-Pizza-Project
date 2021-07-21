namespace CarusoPizza.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants;

    public class Product
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        public int Weight { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public IEnumerable<ProductsToppings> Ingredients { get; init; } = new List<ProductsToppings>();

    }
}
