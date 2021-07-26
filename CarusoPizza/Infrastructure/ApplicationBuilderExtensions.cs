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

            SeedToppings(data);

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

        private static void SeedToppings(CarusoPizzaDbContext data)
        {
            if (data.Toppings.Any())
            {
                return;
            }

            data.Toppings.AddRange(new[]
            {
                new Topping 
                {
                    Name = "fresh mozzarella",
                    Price = 1.50M
                },
                 new Topping
                {
                    Name = "prosciutoo cotto",
                    Price = 1.50M
                },
                new Topping
                {
                    Name = "cheddar cheese",
                    Price = 1.50M
                },
                new Topping
                {
                    Name = "mozzarella",
                    Price = 1.50M
                },
                new Topping
                {
                    Name = "smoked melted cheese",
                    Price = 1.50M
                },
                new Topping
                {
                    Name = "spicy pepperoni",
                    Price = 1.50M
                },
                new Topping
                {
                    Name = "salsiche",
                    Price = 1.50M
                },
                new Topping
                {
                    Name = "red onion",
                    Price = 1.00M
                },
                new Topping
                {
                    Name = "mushrooms",
                    Price = 1.00M
                },
                new Topping
                {
                    Name = "green pepper",
                    Price = 1.00M
                },
                new Topping
                {
                    Name = "jalapenos peppers",
                    Price = 1.00M
                },
                new Topping
                {
                    Name = "cherry tomato",
                    Price = 1.00M
                }
               
            });
        }
        
    }
}