namespace CarusoPizza.Models.Basket
{
    public class SelectedToppingsViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public bool IsOrdered { get; init; }

        public int OrderProductId { get; init; }
    }
}
