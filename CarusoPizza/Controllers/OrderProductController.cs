namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class OrderProductController : Controller
    {
        private readonly CarusoPizzaDbContext data;

        public OrderProductController(CarusoPizzaDbContext data) 
            => this.data = data;

        public IActionResult Order(int id)
        {
            var product = this.data.Products
                .First(p => p.Id == id);

            return this.View(product);
        }
    }
}
