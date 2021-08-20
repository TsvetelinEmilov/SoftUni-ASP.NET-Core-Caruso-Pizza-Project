namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Models.OrderProduct;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderProductController : Controller
    {
        private readonly CarusoPizzaDbContext data;
        private readonly IProductService productService;

        public OrderProductController(
            CarusoPizzaDbContext data,
            IProductService productService)
        {
            this.data = data;
            this.productService = productService;
        }

        public IActionResult Order(int id)
        {
            var product = this.productService.FindById(id);

            return View(new ToBasketFormModel
            {
                PizzaSizes = this.GetPizzaSizes(),
                Toppings = this.GetProductToppings(),
                Product = new ProductListingModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Description = product.Description,
                    CategoryId = product.CategoryId
                }
            });
        }

        [HttpPost]
        public IActionResult Order(int id, ToBasketFormModel productDetails)
        {
            var product = this.productService.FindById(id);

            var selectedToppings = productDetails
                .Toppings
                .Where(x => x.IsOrdered == true)
                .Select(t => new ToppingViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    IsOrdered = t.IsOrdered,
                })
                .ToList();

            if (!ModelState.IsValid)
            {
                productDetails.Toppings = this.GetProductToppings();
                productDetails.PizzaSizes = this.GetPizzaSizes();

                return this.View(productDetails);
            }
            productDetails.Product = new ProductListingModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description
            };      

            decimal productPrice = productDetails.Product.Price * productDetails.Quantity;

            if (selectedToppings.Any())
            {
                foreach (var topping in selectedToppings)
                {
                    productPrice += topping.Price * productDetails.Quantity;
                }
            }

            var orderProductData = new OrderProduct
            {
                ProductId = productDetails.Product.Id,
                Comment = productDetails.Comment,
                PizzaSizeId = productDetails.PizzaSizeId,
                Quantity = productDetails.Quantity,
                Price = productPrice
            };

            foreach (var topping in selectedToppings)
            {
                var orderProductToppings = new OrderProductsToppings
                {
                    OrderProductId = productDetails.Id,
                    ToppingId = topping.Id,
                };
                orderProductData.Toppings.Add(orderProductToppings);
            }


            this.data.OrderProducts.Add(orderProductData);
            this.data.SaveChanges();

            return this.RedirectToAction("All", "Products");
        }

        private IList<ToppingViewModel> GetProductToppings()
            => this.data
            .Toppings
            .Select(p => new ToppingViewModel
            {
                Id = p.Id,
                IsOrdered = p.IsOrdered,
                Name = p.Name,
                Price = p.Price
            })
            .ToList();

        private IEnumerable<PizzaSizeViewModel> GetPizzaSizes()
            => this.data
            .PizzaSizes
            .Select(s => new PizzaSizeViewModel
            {
                Id = s.Id,
                Size = s.Size
            })
            .ToList();
    }
}
