using CarusoPizza.Data;
using CarusoPizza.Models.Basket;
using CarusoPizza.Services.Administrator.Models;
using System.Linq;

namespace CarusoPizza.Services.Administrator
{
    public class AdministratorService : IAdministratorService
    {
        private readonly CarusoPizzaDbContext data;

        public AdministratorService(CarusoPizzaDbContext data) 
            => this.data = data;

        public AdminCurrentOrderServiceModel FindOrderById(int orderId)
        => this.data
            .Orders
            .Where(o => o.Id == orderId)
            .Select(o => new AdminCurrentOrderServiceModel
            {
                SumPrice = o.SumPrice,
                CreatedOn = o.CreatedOn.ToString("yyyy-MM-dd HH':'mm':'ss"),
                FullName = o.FullName,
                CreatorId = o.CreatorId,
                PhoneNumber = o.PhoneNumber,
                Email = o.Email,
                StreetAndNumber = o.StreetAndNumber,
                City = o.City,
                District = o.District,
                Note = o.Note,
                Products = o.Products.Select(p => new BasketProductViewModel
                {
                    Id = p.Id,
                    Price = p.Price,
                    PizzaSizeId = p.PizzaSizeId,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    ProductImage = p.Product.ImageUrl,
                    ProductDescription = p.Product.Description,
                    Comment = p.Comment,
                    Quantity = p.Quantity,
                    UserId = p.UserId,
                    OrderProductToppings = p.OrderProductToppings
                    .Select(t => new SelectedToppingsViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Price = t.Price,
                        IsOrdered = t.IsOrdered,
                        OrderProductId = t.OrderProductId.Value
                    })
                })
            })
            .FirstOrDefault();

        public AdminOrdersQueryServiceModel GetOrders()
        {
            var orderQuery = this.data
                .Orders
                .AsQueryable();

            var orders = orderQuery
                .OrderBy(x => x.CreatedOn)
                .Select(o => new AdminOrderServiceModel
                {
                    OrderId = o.Id,
                    CreatedOn = o.CreatedOn.ToString("yyyy-MM-dd HH':'mm':'ss"),
                    ProductsCount = o.Products.Count(),
                    SumPrice = o.SumPrice
                });
            return new AdminOrdersQueryServiceModel
            {
                Orders = orders
            };
        }
    }
}
