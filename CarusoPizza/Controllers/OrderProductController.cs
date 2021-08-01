namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Models.OrderProduct;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderProductController : Controller
    {
        private readonly CarusoPizzaDbContext data;

        public OrderProductController(CarusoPizzaDbContext data)
            => this.data = data;

        public IActionResult Order(int id)
        {
            return View(new ToBasketFormModel
            {
                PizzaSizes = GetPizzaSizes(),
                Toppings = GetProductToppings(),
                Product = this.data
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description
                })
                .ToList()
            }); 
        }


        [HttpPost]
        public IActionResult Order(int id, ToBasketFormModel productDetails)
        {
            if (!this.data.Categories.Any(c => c.Id == productDetails.ToppingId))
            {
                this.ModelState.AddModelError(nameof(productDetails.ToppingId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                productDetails.Toppings = this.GetProductToppings();
                productDetails.PizzaSizes = this.GetPizzaSizes();

                return this.View(productDetails);
            }

            decimal productPrice = productDetails.Product.Sum(p => p.Price);

            var orderProductData = new OrderProduct
            {
                Comment = productDetails.Comment,
                PizzaSizeId = productDetails.PizzaSizeId,
                Quantity = productDetails.Quantity,
                Price = productPrice * productDetails.Quantity,
                Toppings = (IEnumerable<OrderProductsToppings>)productDetails.Toppings
            };

            this.data.OrderProducts.Add(orderProductData);
            this.data.SaveChanges();

            return this.RedirectToAction("All", "Products");
        }

        private IEnumerable<ToppingViewModel> GetProductToppings()
            => this.data
            .Toppings
            .Select(p => new ToppingViewModel
            {
                Id = p.Id,
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
