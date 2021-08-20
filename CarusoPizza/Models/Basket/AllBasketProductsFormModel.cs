namespace CarusoPizza.Models.Basket
{
    using System.Collections.Generic;

    public class AllBasketProductsFormModel
    {
        public IEnumerable<BasketProductViewModel> Products { get; set; }

        public decimal SumPrice { get; set; }
    }
}
