namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.OrderProduct;
    using CarusoPizza.Services.OrderProduct;
    using CarusoPizza.Services.OrderProduct.Models;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class OrderProductController : Controller
    {
        private readonly CarusoPizzaDbContext data;
        private readonly IProductService productService;
        private readonly IOrderProductService orderProductService;

        public OrderProductController(
            CarusoPizzaDbContext data,
            IProductService productService,
            IOrderProductService orderProductService)
        {
            this.data = data;
            this.productService = productService;
            this.orderProductService = orderProductService;
        }
        [Authorize]
        public IActionResult Order(int id)
        {
            var product = this.productService.FindById(id);

            if (User.GetId() == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            if (product.IsStopped)
            {
                return BadRequest();
            }

            return View(new ToBasketFormModel
            {
                PizzaSizes = this.orderProductService.PizzaSizes(),
                Toppings = this.orderProductService.ProductsToppings(),
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
        [Authorize]
        [HttpPost]
        public IActionResult Order(int id, ToBasketFormModel productDetails)
        {
            var userId = User.GetId();

            var product = this.productService.FindById(id);

            var selectedToppings = productDetails
                .Toppings
                .Where(x => x.IsOrdered == true)
                .Select(t => new ToppingServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    IsOrdered = t.IsOrdered,
                })
                .ToList();

            if (userId == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            if (product.IsStopped)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                productDetails.Toppings = this.orderProductService.ProductsToppings();
                productDetails.PizzaSizes = this.orderProductService.PizzaSizes();

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
                Price = productPrice,
                UserId = userId
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

    }
}
