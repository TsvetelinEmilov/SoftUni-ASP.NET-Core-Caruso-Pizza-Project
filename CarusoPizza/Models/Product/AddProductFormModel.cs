namespace CarusoPizza.Models.Product
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Product;
    public class AddProductFormModel
    {
        [Required]
        [StringLength(
            ProductNameMaxLength,
            MinimumLength = ProductNameMinLength)]
        public string Name { get; init; }

        public int Weight { get; init; }

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

        public int ToppingId { get; init; }

        public IEnumerable<ProductToppingViewModel> Toppings { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; }
    }
}
