namespace CarusoPizza.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Models.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly CarusoPizzaDbContext data;

        public ProductsController(CarusoPizzaDbContext data)
            => this.data = data;

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

            var productData = new Product
            {
                Name = product.Name,
                Weight = product.Weight,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult All([FromQuery]AllProductsQueryModel query)
        {
            var productQuery = this.data.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                productQuery = productQuery.Where(p =>
                       p.Name.ToLower().Contains(query.SearchTerm.ToLower()) ||
                       p.Description.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var totalProducts = productQuery.Count();

            var products = productQuery
                .OrderBy(p => p.Id)
                .Skip((query.CurrentPage - 1) * AllProductsQueryModel.ProductsPerPage)
                .Take(AllProductsQueryModel.ProductsPerPage)
                .Select(p => new ProductsListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description
                })
                .ToList();

            query.TotalProducts = totalProducts;
            query.Products = products;

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
