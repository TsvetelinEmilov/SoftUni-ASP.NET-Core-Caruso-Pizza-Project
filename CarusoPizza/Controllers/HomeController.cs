namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Models;
    using CarusoPizza.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly CarusoPizzaDbContext data;

        private const int CategoryPizzaId = 1;

        public HomeController(CarusoPizzaDbContext data)
            => this.data = data;
        public IActionResult Index()
        {
            var products = this.data
                .Products
                .OrderByDescending(c => c.CategoryId == CategoryPizzaId)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .Take(3)
                .ToList();

            return View(new IndexViewModel
            {
                Products = products
            });



        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
