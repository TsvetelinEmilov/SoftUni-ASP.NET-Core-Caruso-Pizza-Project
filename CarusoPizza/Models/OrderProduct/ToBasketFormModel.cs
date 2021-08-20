namespace CarusoPizza.Models.OrderProduct
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Basket;

    public class ToBasketFormModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductListingModel Product { get; set; }

        public decimal SumPrice { get; set; } 

        [Display(Name = "Pizza Size")]
        public int? PizzaSizeId { get; init; }

        public IEnumerable<PizzaSizeViewModel> PizzaSizes { get; set; }

        [Range(QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; init; }

        [MaxLength(CommentMaxLength)]
        public string Comment { get; init; }

        [Display(Name = "Toppings")]
        public int? ToppingId { get; init; }

        public IList<ToppingViewModel> Toppings { get; set; } = new List<ToppingViewModel>();
    }
}
