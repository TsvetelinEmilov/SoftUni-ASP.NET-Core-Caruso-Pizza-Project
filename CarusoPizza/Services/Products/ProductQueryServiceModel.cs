namespace CarusoPizza.Services
{
    using CarusoPizza.Services.Products;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductQueryServiceModel
    {
        public const int ProductsPerPage = 6;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProducts { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
    }
}
