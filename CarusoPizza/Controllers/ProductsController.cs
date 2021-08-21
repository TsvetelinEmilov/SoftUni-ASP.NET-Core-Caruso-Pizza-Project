namespace CarusoPizza.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarusoPizza.Data;
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.Products;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Add()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new AddProductFormModel
            {
                Categories = this.GetProductCategories()
            });
        }
            
        [Authorize]
        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

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
        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var product = this.products.FindById(id);

            var productForm = new AddProductFormModel
            {
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Weight = product.Weight,
                CategoryId = product.CategoryId
            };

            productForm.Categories = this.GetProductCategories();

            return View(productForm);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, AddProductFormModel product)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                product.Categories = this.GetProductCategories();

                return this.View(product);
            }

            this.products.Edit(
                id,
                product.Name,
                product.Price,
                product.ImageUrl,
                product.Description,
                product.Weight,
                product.CategoryId);

            return RedirectToAction(nameof(All));

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
