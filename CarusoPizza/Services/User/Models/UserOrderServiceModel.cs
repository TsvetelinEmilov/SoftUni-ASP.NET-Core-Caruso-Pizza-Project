namespace CarusoPizza.Services.User.Models
{
    public class UserOrderServiceModel
    {
        public int OrderId { get; init; }

        public string CreatedOn { get; init; }

        public int ProductsCount { get; init; }

        public decimal SumPrice { get; init; }
    }
}
