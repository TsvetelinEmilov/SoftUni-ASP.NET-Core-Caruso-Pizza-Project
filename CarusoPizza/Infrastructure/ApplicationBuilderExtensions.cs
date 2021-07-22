namespace CarusoPizza.Infrastructure
{
    using System.Linq;
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<CarusoPizzaDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(CarusoPizzaDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Pizza" },
                new Category { Name = "Sub" },
                new Category { Name = "Drink" },
                new Category { Name = "Sauce" },
        
            });

            data.SaveChanges();
        }
        
    }
}