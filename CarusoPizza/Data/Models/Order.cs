namespace CarusoPizza.Data.Models
{
    using System;

    public class Order
    {
        public int Id { get; init; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; init; }

        public int BasketId { get; set; }

        public Basket Basket { get; init; }
    }
}
