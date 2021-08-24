namespace CarusoPizza.Services.Order
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Services.OrderProduct.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class OrderService : IOrderService
    {
        private readonly CarusoPizzaDbContext data;

        public OrderService(CarusoPizzaDbContext data) 
            => this.data = data;

        public int CreateOrder(
            decimal sumPrice,
            string phoneNumber,
            string fullName,
            string email,
            string city,
            string district,
            string streetAndNumber,
            string note,
            IEnumerable<OrderProductServiceModel> orderProducts,
            string userId)
        {
            var orderProductDataColletion = new List<OrderProduct>();

            foreach (var orderProduct in orderProducts)
            {
                List<OrderProduct> orderProductData = this.data.OrderProducts.Where(op => op.Id == orderProduct.Id).ToList();

                foreach (var product in orderProductData)
                {
                    product.IsOrdered = true;
                }
                orderProductDataColletion.AddRange(orderProductData);
                
            }

            var orderData = new Order
            {
                SumPrice = sumPrice,
                PhoneNumber = phoneNumber,
                FullName = fullName,
                Email = email,
                City = city,
                District = district,
                StreetAndNumber = streetAndNumber,
                Note = note,
                Products = orderProductDataColletion,
                CreatorId = userId,
                CreatedOn = DateTime.Now,
            };

            this.data.Orders.Add(orderData);
            this.data.SaveChanges();

            return orderData.Id;
        }

        public bool AddReview(int orderId, string review)
        {
            var order = this.data.Orders.FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                return false;
            }

            order.Review = review;

            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<OrderProductServiceModel> OrderProductsByUser(string userId)
            => this.data
            .OrderProducts
            .Where(op => op.IsOrdered == false && op.UserId == userId)
            .Select(p => new OrderProductServiceModel
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Name = p.Product.Name,
                Price = p.Price,
                PizzaSizeId = p.PizzaSizeId,
                Comment = p.Comment,
                Quantity = p.Quantity,
                UserId = p.UserId,
                Toppings = p.OrderProductToppings.Select(t => new ToppingServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    IsOrdered = t.IsOrdered,
                    OrderProductId = t.OrderProductId.Value
                })
            }).ToList();
    }
}
