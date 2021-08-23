namespace CarusoPizza.Services.Basket
{
    using System.Linq;
    using CarusoPizza.Data;
    using CarusoPizza.Data.Models;
    using CarusoPizza.Services.OrderProduct.Models;
    using CarusoPizza.Services.Products.Modelis;
    using System.Collections.Generic;

    public class BasketService : IBasketService
    {
        private readonly CarusoPizzaDbContext data;

        public BasketService(CarusoPizzaDbContext data) 
            => this.data = data;

        public bool Edit(int id,
            int productId,
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

            var product = this.data
                .Products
                .Find(productId);

            decimal productPrice = product.Price * quantity;

            if (toppings.Any())
            {
                foreach (var topping in toppings)
                {
                    productPrice += topping.Price * quantity;
                }
            }

            orderProduct.Comment = comment;
            orderProduct.PizzaSizeId = pizzaSizeId;
            orderProduct.Quantity = quantity;
            orderProduct.Price = productPrice;
            
            foreach (var topping in toppings)
            {
                
                var orderProductToppings = new OrderProductsToppings
                {
                    OrderProductId = id,
                    ToppingId = topping.Id,
                };
                if (orderProduct.Toppings.Contains(orderProductToppings))
                {

                }
                orderProduct.Toppings.Add(orderProductToppings);
            }

            this.data.SaveChanges();

            return true;
        }
    }
}
