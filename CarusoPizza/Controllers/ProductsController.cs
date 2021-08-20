namespace CarusoPizza.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarusoPizza.Data;
    using CarusoPizza.Models.Products;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly IProductService products;
        private readonly CarusoPizzaDbContext data;

        public ProductsController(
            CarusoPizzaDbContext data,
            IProductService products)
        {
            this.data = data;
            this.products = products;
        }

        public IActionResult Add()
            => View(new AddProductFormModel
            {
                Categories = this.GetProductCategories()
            });

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                product.Categories = this.GetProductCategories();

                return this.View(product);
            }

            this.products.Add(product.Name,
                product.Weight,
                product.Price,
                product.Description,
                product.ImageUrl,
                product.CategoryId);

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult All([FromQuery]AllProductsQueryModel query)
        {
            var queryResult = this.products.All(
                query.SearchTerm,
                query.CurrentPage,
                AllProductsQueryModel.ProductsPerPage);

            query.TotalProducts = queryResult.TotalProducts;
            query.Products = queryResult.Products;

            return View(query);
        }

        private IEnumerable<ProductCategoryViewModel> GetProductCategories()
            => this.data
            .Categories
            .Select(p => new ProductCategoryViewModel
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToList();
    }
}
