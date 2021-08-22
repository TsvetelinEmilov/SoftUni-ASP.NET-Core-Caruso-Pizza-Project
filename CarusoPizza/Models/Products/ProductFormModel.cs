namespace CarusoPizza.Models.Products
{
    using CarusoPizza.Services.Products.Modelis;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Product;
    public class ProductFormModel
    {
        [Required]
        [StringLength(
            NameMaxLength,
            MinimumLength = NameMinLength)]
        public string Name { get; init; }

        public int Weight { get; init; }

        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; init; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(
            DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Description { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<ProductCategoryServiceModel> Categories { get; set; }
    }
}
