namespace CarusoPizza.Controllers
{
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.User;
    using CarusoPizza.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
            => this.userService = userService;

        [Authorize]
        public IActionResult Orders(string userId, [FromQuery] AllUsersOrdersQueryModel query)
        {
            if (User.GetId() != userId)
            {
                return BadRequest();
            }
            var queryResult = this.userService.GetOrders(userId);

            query.Orders = queryResult.Orders;


            return View(query);
        }
    }
}
