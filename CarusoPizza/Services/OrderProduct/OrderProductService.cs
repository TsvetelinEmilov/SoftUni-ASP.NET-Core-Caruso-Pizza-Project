namespace CarusoPizza.Services.OrderProduct
{
    using CarusoPizza.Data;
    using CarusoPizza.Services.OrderProduct.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderProductService : IOrderProductService
    {
        private readonly CarusoPizzaDbContext data;

        public OrderProductService(CarusoPizzaDbContext data)
            => this.data = data;

        public IList<ToppingServiceModel> ProductsToppings()
        => this.data
            .Toppings
            .Select(p => new ToppingServiceModel
            {
                Id = p.Id,
                IsOrdered = p.IsOrdered,
                Name = p.Name,
                Price = p.Price
            })
            .ToList();
        public IEnumerable<PizzaSizeServiceModel> PizzaSizes()
            => this.data
            .PizzaSizes
            .Select(s => new PizzaSizeServiceModel
            {
                Id = s.Id,
                Size = s.Size
            })
            .ToList();

        public OrderProductServiceModel FindById(int id)
            => this.data.OrderProducts
            .Where(op => op.Id == id)
            .Select(p => new OrderProductServiceModel
            {
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
            })
            .FirstOrDefault();

        public bool Remove(int productId, string userId)
        {
            var productToRemove = this.data
               .OrderProducts
               .Where(p => p.Id == productId && p.UserId == userId)
               .FirstOrDefault();

            if (productToRemove == null)
            {
                return false;
            }

            this.data.OrderProducts.Remove(productToRemove);
            this.data.SaveChanges();

            return true;
        }
    }
}
