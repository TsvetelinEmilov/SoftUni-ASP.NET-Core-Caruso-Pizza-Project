namespace CarusoPizza.Services.User
{
    using CarusoPizza.Data;
    using CarusoPizza.Services.User.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly CarusoPizzaDbContext data;

        public UserService(CarusoPizzaDbContext data) 
            => this.data = data;

        public UsersOrdersQueryServiceModel GetOrders(string userId)
        {
            var orderQuery = this.data
                .Orders
                .Where(u => u.CreatorId == userId)
                .AsQueryable();

            var orders = orderQuery
                .OrderByDescending(x => x.CreatedOn)
                .Select(o => new UserOrderServiceModel
                {
                    OrderId = o.Id,
                    CreatedOn = o.CreatedOn.ToString("yyyy-MM-dd HH':'mm':'ss"),
                    ProductsCount = o.Products.Count(),
                    SumPrice = o.SumPrice
                });
            return new UsersOrdersQueryServiceModel
            {
                Orders = orders
            };        
        }
    }
}
