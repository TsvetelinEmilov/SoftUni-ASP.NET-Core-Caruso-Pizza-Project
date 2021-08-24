namespace CarusoPizza.Controllers
{
    using CarusoPizza.Models;
    using CarusoPizza.Models.Home;
    using CarusoPizza.Services.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
            => this.homeService = homeService;
        public IActionResult Index()
        {
            var products = homeService.GetProducts();
            return View(new IndexViewModel
            {
                Products = products
            });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
