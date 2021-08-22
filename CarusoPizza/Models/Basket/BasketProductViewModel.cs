namespace CarusoPizza.Models.Basket
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BasketProductViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; init; }

        public string ProductName { get; init; }

        public string ProductImage { get; init; }

        public string ProductDescription { get; init; }

        public decimal Price { get; set; }

        [Display(Name = "Pizza Size")]
        public int? PizzaSizeId { get; init; }

        public int Quantity { get; init; }

        public string Comment { get; init; }

        public string UserId { get; init; }

        public IEnumerable<SelectedToppingsViewModel> Toppings { get; init; }

    }
}
