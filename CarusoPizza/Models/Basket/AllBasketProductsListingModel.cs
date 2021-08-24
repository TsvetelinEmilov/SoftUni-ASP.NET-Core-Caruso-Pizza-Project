namespace CarusoPizza.Models.Basket
{
    using System.Collections.Generic;

    public class AllBasketProductsListingModel
    {
        public IEnumerable<BasketProductViewModel> Products { get; set; }

    }
}
