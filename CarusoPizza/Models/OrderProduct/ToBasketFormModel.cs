namespace CarusoPizza.Models.OrderProduct
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Basket;

    public class ToBasketFormModel
    {
        public int ProductId { get; set; }

        public IEnumerable<ProductListingModel> Product { get; set; }

        public decimal SumPrice { get; set; } 

        [Display(Name = "Pizza Size")]
        public int PizzaSizeId { get; init; }

        public IEnumerable<PizzaSizeViewModel> PizzaSizes { get; set; }

        public int Quantity { get; init; }

        [MaxLength(CommentMaxLength)]
        public string Comment { get; init; }

        [Display(Name = "Toppings")]
        public int ToppingId { get; init; }

        public IEnumerable<ToppingViewModel> Toppings { get; set; }
    }
}
