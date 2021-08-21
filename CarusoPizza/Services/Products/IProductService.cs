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
        bool Edit(
            int id,
            string name,
            decimal price,
            string imageUrl,
            string description,
            int weight,
            int categoryId);

        ProductServiceModel FindById(int id);


    }
}
