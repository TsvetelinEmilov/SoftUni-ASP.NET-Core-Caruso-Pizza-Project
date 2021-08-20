namespace CarusoPizza.Models.Basket
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BasketProductViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Pizza Size")]
        public int? PizzaSizeId { get; init; }

        public int Quantity { get; init; }

        public string Comment { get; init; }

        public IEnumerable<SelectedToppingsViewModel> Toppings { get; init; }

    }
}
