namespace CarusoPizza.Services.Basket
{
    using CarusoPizza.Services.OrderProduct.Models;
    using System.Collections.Generic;

    public interface IBasketService
    {
         bool Edit(int id, string comment, int pizzaSizeId, int quantity, decimal price, IList<ToppingServiceModel> toppings);
    }
}
