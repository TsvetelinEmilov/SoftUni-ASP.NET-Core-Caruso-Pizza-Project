namespace CarusoPizza.Controllers
{
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.Administrator;
    using CarusoPizza.Services.Administrator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AdministratorController : Controller
    {
        private readonly IAdministratorService adminService;

        public AdministratorController(IAdministratorService adminService)
            => this.adminService = adminService;

        [Authorize]
        public IActionResult Orders([FromQuery] AllOrdersQueryModel query)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }
            var queryResult = this.adminService.GetOrders();

            query.Orders = queryResult.Orders;


            return View(query);
        }
        [Authorize]
        public IActionResult Details(int orderId)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            var order = this.adminService.FindOrderById(orderId);

            return View(new OrderViewModel
            {
                SumPrice = order.SumPrice,
                CreatedOn = order.CreatedOn,
                FullName = order.FullName,
                CreatorId = order.CreatorId,
                PhoneNumber = order.PhoneNumber,
                Email = order.Email,
                StreetAndNumber = order.StreetAndNumber,
                City = order.City,
                District = order.District,
                Note = order.Note,
                Review = order.Review,
                Products = order.Products
            });
        }
    }
}
