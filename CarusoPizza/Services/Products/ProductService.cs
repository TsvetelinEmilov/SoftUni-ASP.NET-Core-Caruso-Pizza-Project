namespace CarusoPizza.Services.Products
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using System.Linq;
    public class ProductService : IProductService
    {
        private readonly CarusoPizzaDbContext data;

        public ProductService(CarusoPizzaDbContext data)
        {
            this.data = data;
        }

        public ProductServiceModel FindById(int id)
            => this.data
            .Products
            .Select(p => new ProductServiceModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                CategoryId = p.CategoryId
            })
            .FirstOrDefault(p => p.Id == id);

        public ProductQueryServiceModel All(
            string searchTerm,
            int currentPage,
            int productsPerPage)
        {
            var productQuery = this.data
                .Products
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productQuery = productQuery
                    .Where(p =>
                           p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                           p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalProducts = productQuery.Count();

            var products = productQuery
                .OrderBy(p => p.Id)
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    CategoryId = p.CategoryId

                })
                .ToList();

            return new ProductQueryServiceModel
            {
                TotalProducts = totalProducts,
                Products = products
            };
        }

        public int Add(
            string name,
            int weight,
            decimal price,
            string description,
            string imageUrl,
            int categoryId)
        {
            var productData = new Product
            {
                Name = name,
                Weight = weight,
                Price = price,
                Description = description,
                ImageUrl = imageUrl,
                CategoryId = categoryId
            };

            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return productData.Id;
        }
        public bool Edit(int id, string name, decimal price, string imageUrl, string description, int weight, int categoryId)
        {
            var product = this.data.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            product.Name = name;
            product.Price = price;
            product.ImageUrl = imageUrl;
            product.Description = description;
            product.Weight = weight;
            product.CategoryId = categoryId;

            this.data.SaveChanges();

            return true;
        }
    }
}
