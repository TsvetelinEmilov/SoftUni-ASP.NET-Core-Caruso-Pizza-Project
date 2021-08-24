namespace CarusoPizza.Services.User.Models
{
    public class OrderServiceModel
    {
        public string CreatedOn { get; init; }

        public int ProductsCount { get; init; }

        public decimal SumPrice { get; init; }
    }
}
