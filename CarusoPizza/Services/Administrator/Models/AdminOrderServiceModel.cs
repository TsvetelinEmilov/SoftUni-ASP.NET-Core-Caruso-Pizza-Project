namespace CarusoPizza.Services.Administrator.Models
{
    public class AdminOrderServiceModel
    {
        public int OrderId { get; init; }

        public string CreatedOn { get; init; }

        public int ProductsCount { get; init; }

        public decimal SumPrice { get; init; }
    }
}
