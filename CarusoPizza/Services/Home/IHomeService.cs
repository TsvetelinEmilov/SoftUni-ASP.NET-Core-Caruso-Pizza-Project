namespace CarusoPizza.Services.Home
{
    using CarusoPizza.Services.Home.Models;
    using System.Collections.Generic;

    public interface IHomeService
    {
        List<ProductIndexServiceModel> GetProducts();
    }
}
