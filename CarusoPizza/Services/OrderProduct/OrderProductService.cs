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

    }
}
