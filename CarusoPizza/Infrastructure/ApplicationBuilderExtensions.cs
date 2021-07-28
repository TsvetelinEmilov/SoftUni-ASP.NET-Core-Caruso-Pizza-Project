namespace CarusoPizza.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using static WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);

            SeedToppings(services);

            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {

            var data = services.GetRequiredService<CarusoPizzaDbContext>();

            data.Database.Migrate();

        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<CarusoPizzaDbContext>();

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

        private static void SeedToppings(IServiceProvider services)
        {
            var data = services.GetRequiredService<CarusoPizzaDbContext>();

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

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run( async() =>                          
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@caruso.com";
                    const string adminPassword = "admincaruso1";

                    var applicationUser = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FirstName = "Admin"
                    };

                    await userManager.CreateAsync(applicationUser, adminPassword);

                    await userManager.AddToRoleAsync(applicationUser, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
        
    }
}