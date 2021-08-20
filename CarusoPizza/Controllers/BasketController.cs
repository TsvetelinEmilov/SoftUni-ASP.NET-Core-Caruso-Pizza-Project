namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Models.Basket;
    using CarusoPizza.Models.OrderProduct;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class BasketController : Controller
    {
        private readonly CarusoPizzaDbContext data;
        private readonly IProductService productService;

        public BasketController(CarusoPizzaDbContext data, IProductService productService)
        {
            this.data = data;
            this.productService = productService;
        }

        public IActionResult Index(AllBasketProductsFormModel query)
        {
            //var queryResult = this.products.All(
            //    query.SearchTerm,
            //    query.CurrentPage,
            //    AllProductsQueryModel.ProductsPerPage);

            //query.TotalProducts = queryResult.TotalProducts;
            //query.Products = queryResult.Products;

            //return View(query);
            query.Products = this.data
                .OrderProducts
                .Select(p => new BasketProductViewModel
                {
                    Id = p.Id,
                    Price = p.Price,
                    PizzaSizeId = p.PizzaSizeId,
                    ProductId = p.ProductId,
                    Comment = p.Comment,
                    Quantity = p.Quantity,
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

        //public IActionResult Add()
        //{
        //}
    }
}
