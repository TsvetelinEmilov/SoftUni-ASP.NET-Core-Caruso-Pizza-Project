﻿namespace CarusoPizza.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Models.Product;
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
