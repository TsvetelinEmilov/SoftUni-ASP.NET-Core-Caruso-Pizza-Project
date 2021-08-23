using System.Collections.Generic;

namespace CarusoPizza.Services.OrderProduct.Models
{
    public class OrderProductServiceModel
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int PizzaSizeId { get; init; }

        public int Quantity { get; init; }

        public string Comment { get; init; }

        public string UserId { get; init; }

        public IEnumerable<ToppingServiceModel> Toppings { get; set; }
    }
}
