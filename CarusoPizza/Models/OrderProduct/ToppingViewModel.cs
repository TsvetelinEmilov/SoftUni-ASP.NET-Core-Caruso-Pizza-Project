namespace CarusoPizza.Models.OrderProduct
{
    public class ToppingViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public bool IsOrdered { get; set; } = false;

        public decimal Price { get; set; }
    }
}
