namespace CarusoPizza.Services.Products
{
    using CarusoPizza.Data.Models;

    public interface IProductService
    {
        ProductQueryServiceModel All(
            string searchTerm,
            int currentPage,
            int productsPerPage);

        int Add(
            string name,
            int weight,
            decimal price,
            string description,
            string imageUrl,
            int categoryId);

        ProductServiceModel FindById(int id);


    }
}
