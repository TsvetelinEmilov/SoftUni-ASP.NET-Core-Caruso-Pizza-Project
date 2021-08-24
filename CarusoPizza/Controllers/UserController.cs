namespace CarusoPizza.Controllers
{
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.Administrator;
    using CarusoPizza.Models.User;
    using CarusoPizza.Services.Administrator;
    using CarusoPizza.Services.Order;
    using CarusoPizza.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IAdministratorService adminService;
        private readonly IOrderService orderService;

        public UserController(
            IUserService userService,
            IAdministratorService adminService,
            IOrderService orderService)
        {
            this.userService = userService;
            this.adminService = adminService;
            this.orderService = orderService;
        }

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

        [Authorize]
        public IActionResult Details(int orderId, string userId)
        {
            if (User.GetId() != userId)
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
        [Authorize]
        public IActionResult Review(int orderId, string userId)
        {
            if (User.GetId() != userId)
            {
                return BadRequest();
            }
            return View(new ReviewFormModel());
        }
       [Authorize]
       [HttpPost]
       public IActionResult Review(int orderId, string userId, ReviewFormModel reviewModel)
       {
            if (User.GetId() != userId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View(reviewModel);
            }

            this.orderService.AddReview(orderId, reviewModel.Review);

            return Redirect("~/Home/Index");
        }
    }
}
