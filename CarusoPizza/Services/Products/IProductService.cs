namespace CarusoPizza.Services.Products
{
    using CarusoPizza.Services.Products.Modelis;
    using System.Collections.Generic;

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
            int weight,
            decimal price,
            string description,
            string imageUrl,
            int categoryId);

        bool Delete(int id);

        ProductServiceModel FindById(int id);

        IEnumerable<ProductCategoryServiceModel> ProductsCategories();

        bool CategoryExists(int categoryId);


    }
}
