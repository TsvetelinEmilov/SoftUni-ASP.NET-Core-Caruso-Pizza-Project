namespace CarusoPizza.Services.Home
{
    using CarusoPizza.Data;
    using CarusoPizza.Services.Home.Models;
    using System.Collections.Generic;
    using System.Linq;
    public class HomeService : IHomeService
    {
        private readonly CarusoPizzaDbContext data;

        private const int CategoryPizzaId = 1;

        public HomeService(CarusoPizzaDbContext data) 
            => this.data = data;

        public List<ProductIndexServiceModel> GetProducts()
            => this.data
                .Products
                .OrderByDescending(c => c.CategoryId == CategoryPizzaId)
                .Select(p => new ProductIndexServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .Take(3)
                .ToList();

    }
}
