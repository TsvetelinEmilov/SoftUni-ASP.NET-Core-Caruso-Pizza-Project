namespace CarusoPizza.Services.Administrator.Models
{
    using CarusoPizza.Models.Basket;
    using System.Collections.Generic;

    public class AdminCurrentOrderServiceModel
    {
        public string CreatedOn { get; set; }

        public decimal SumPrice { get; init; }

        public string CreatorId { get; set; }

        public string PhoneNumber { get; init; }

        public string FullName { get; init; }

        public string Email { get; init; }

        public string City { get; init; }

        public string District { get; init; }

        public string StreetAndNumber { get; init; }

        public string Note { get; init; }

        public IEnumerable<BasketProductViewModel> Products { get; set; }
    }
}
