namespace CarusoPizza.Models.Product
{
    using CarusoPizza.Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Product;
    public class OrderProductFormModel
    {
        [Required]
        [StringLength(
            ProductNameMaxLength,
            MinimumLength = ProductNameMinLength)]
        public string Name { get; init; }

        [Range(ProductPriceMinValue, ProductPriceMaxValue)]
        public decimal Price { get; init; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(
           ProductDescriptionMaxLength,
           MinimumLength = ProductDescriptionMinLength,
           ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Description { get; init; }

        public PizzaSize PizzaMediumSize { get; set; } = PizzaSize.Medium;
        public PizzaSize PizzaLargeSize { get; set; } = PizzaSize.Large;

        [Display(Name = "Toppings")]
        public int ToppingId { get; init; }

        public IEnumerable<ProductToppingViewModel> Toppings { get; set; }
    }
}
