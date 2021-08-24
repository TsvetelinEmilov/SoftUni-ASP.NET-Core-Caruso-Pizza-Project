namespace CarusoPizza.Controllers
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System;
    using CarusoPizza.Services.Order;
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.Order;
    using Microsoft.AspNetCore.Authorization;

    public class OrdersController : Controller
    {
        private readonly CarusoPizzaDbContext data;
        private readonly IOrderService orderService;

        public OrdersController(
            CarusoPizzaDbContext data,
            IOrderService orderService)
        {
            this.data = data;
            this.orderService = orderService;
        }
        [Authorize]
        public IActionResult Finish(string userId)
        {
            if (User.GetId() != userId)
            {
                return BadRequest();
            }


            return View(new OrderFormModel
            {
                SumPrice = orderService.OrderProductsByUser(userId).Sum(x => x.Price),
                Products = orderService.OrderProductsByUser(userId)
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Finish(string userId, OrderFormModel orderForm)
        {
            if (User.GetId() != userId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                orderForm.Products = this.orderService.OrderProductsByUser(userId);

                return this.View(orderForm);
            }

            var orderProductsCollection = orderService.OrderProductsByUser(userId);

            var sumPrice = orderService.OrderProductsByUser(userId).Sum(x => x.Price);

            this.orderService.CreateOrder(
                sumPrice,
                orderForm.PhoneNumber,
                orderForm.FullName,
                orderForm.Email,
                orderForm.City,
                orderForm.District,
                orderForm.StreetAndNumber, 
                orderForm.Note, 
                orderProductsCollection,
                userId);

            return Redirect("~/Home/Index");

          
        }
    }
}
