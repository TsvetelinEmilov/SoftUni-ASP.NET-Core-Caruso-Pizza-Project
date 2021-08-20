namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        private readonly CarusoPizzaDbContext data;

        public OrdersController(CarusoPizzaDbContext data) 
            => this.data = data;
    }
}
