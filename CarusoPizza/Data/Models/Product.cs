namespace CarusoPizza.Data.Models
{
    using CarusoPizza.Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants.Product;

    public class Product
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        public PizzaSize? PizzaSize { get; set; }

        public int? Weight { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; init; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public IEnumerable<ProductsToppings> Toppings { get; init; } = new List<ProductsToppings>();

    }
}
