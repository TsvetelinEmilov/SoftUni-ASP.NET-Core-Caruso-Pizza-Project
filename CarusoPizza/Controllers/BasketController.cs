namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.Basket;
    using CarusoPizza.Models.OrderProduct;
    using CarusoPizza.Services.Basket;
    using CarusoPizza.Services.OrderProduct;
    using CarusoPizza.Services.OrderProduct.Models;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class BasketController : Controller
    {
        private readonly CarusoPizzaDbContext data;
        private readonly IProductService productService;
        private readonly IOrderProductService orderProductService;
        private readonly IBasketService basketService;

        public BasketController(
            CarusoPizzaDbContext data,
            IProductService productService,
            IOrderProductService orderProductService,
            IBasketService basketService)
        {
            this.orderProductService = orderProductService;
            this.data = data;
            this.productService = productService;
            this.basketService = basketService;
        }
        [Authorize]
        public IActionResult Index(AllBasketProductsFormModel query)
        {
            var userId = User.GetId();

            if (userId == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            query.Products = this.data
                .OrderProducts
                .Where(u => u.UserId == userId)
                .Select(p => new BasketProductViewModel
                {
                    Id = p.Id,
                    Price = p.Price,
                    PizzaSizeId = p.PizzaSizeId,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    ProductImage = p.Product.ImageUrl,
                    ProductDescription = p.Product.Description,
                    Comment = p.Comment,
                    Quantity = p.Quantity,
                    UserId = p.UserId,
                    Toppings = p.Toppings
                    .Select(t => new SelectedToppingsViewModel
                    {
                        Id = t.ToppingId,
                        Name = t.Topping.Name,
                        Price = t.Topping.Price

                    })
                })
                .ToList();

            return View(query);
        }
        [Authorize]
        public IActionResult Remove(int productId, string userId)
        {
            if (User.GetId() != userId)
            {
                return BadRequest();
            }

            var productToRemove = this.orderProductService.Remove(productId, userId);

            if (!productToRemove)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public IActionResult Edit(int id, int productId)
        {
            var product = this.productService.FindById(productId);

            var orderProduct = this.orderProductService.FindById(id);

            if (User.GetId() != orderProduct.UserId)
            {
                return BadRequest();
            }

            return View(new ToBasketFormModel
            {
                PizzaSizes = this.orderProductService.PizzaSizes(),
                Toppings = this.orderProductService.ProductsToppings(),
                Product = product,
                PizzaSizeId = orderProduct.PizzaSizeId,
                Price = orderProduct.Price,
                UserId = orderProduct.UserId,
                Comment = orderProduct.Comment,
                Quantity = orderProduct.Quantity,
                ProductId = orderProduct.ProductId
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, ToBasketFormModel modelProduct)
         {
            if (!ModelState.IsValid)
            {
                modelProduct.Toppings = this.orderProductService.ProductsToppings();
                modelProduct.PizzaSizes = this.orderProductService.PizzaSizes();

                return this.View(modelProduct);
            }

            var orderProduct = this.orderProductService.FindById(id);

            if (orderProduct.UserId != User.GetId())
            {
                return BadRequest();
            }

            var selectedToppings = modelProduct
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

            foreach (var topping in orderProduct.Toppings)
            {
                if (selectedToppings.Any(t => t.Name == topping.Name))
                {
                    var toppingToRemove = selectedToppings.FirstOrDefault(t => t.Name == topping.Name);
                    selectedToppings.Remove(toppingToRemove);
                }
            }

            this.basketService.Edit(id,
                orderProduct.ProductId,
                modelProduct.Comment,
                modelProduct.PizzaSizeId,
                modelProduct.Quantity,
                orderProduct.Price,
                selectedToppings);

            return RedirectToAction(nameof(Index));
        }

    }
}
