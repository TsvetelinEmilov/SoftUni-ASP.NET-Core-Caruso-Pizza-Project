namespace CarusoPizza.Data
{
    using CarusoPizza.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CarusoPizzaDbContext : IdentityDbContext<User>
    {
        public CarusoPizzaDbContext(DbContextOptions<CarusoPizzaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Topping> Toppings { get; init; }

        public DbSet<Order> Orders { get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Order>()
                .HasOne(u => u.Creator)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ProductsToppings>().HasKey(x => new
                {
                    x.ProductId,
                    x.ToppingId
                });

            base.OnModelCreating(builder);
        }

    }
}
