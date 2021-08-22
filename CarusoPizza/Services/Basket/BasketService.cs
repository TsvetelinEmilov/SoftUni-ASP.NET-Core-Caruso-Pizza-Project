namespace CarusoPizza.Services.Basket
{
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Services.OrderProduct.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class BasketService : IBasketService
    {
        private readonly CarusoPizzaDbContext data;

        public BasketService(CarusoPizzaDbContext data) 
            => this.data = data;

        public bool Edit(int id,
            string comment,
            int pizzaSizeId,
            int quantity,
            decimal price,
            IList<ToppingServiceModel> toppings)
        {
            var orderProduct = this.data
                .OrderProducts
                .Find(id);

            if (orderProduct == null)
            {
                return false;
            }

            orderProduct.Comment = comment;
            orderProduct.PizzaSizeId = pizzaSizeId;
            orderProduct.Quantity = quantity;
            orderProduct.Price = price;
            foreach (var topping in toppings)
            {
                var orderProductToppings = new OrderProductsToppings
                {
                    OrderProductId = id,
                    ToppingId = topping.Id,
                };
                orderProduct.Toppings.Add(orderProductToppings);
            }

            this.data.SaveChanges();

            return true;
        }

    }
}
