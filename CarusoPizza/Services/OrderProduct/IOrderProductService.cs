namespace CarusoPizza.Services.OrderProduct
{
    using CarusoPizza.Services.OrderProduct.Models;
    using System.Collections.Generic;

    public interface IOrderProductService
    {
        IList<ToppingServiceModel> ProductsToppings();

        IEnumerable<PizzaSizeServiceModel> PizzaSizes();
    }
}
