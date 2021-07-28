namespace CarusoPizza.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; init; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; init; }

        public IEnumerable<OrderProduct> Products { get; init; } = new List<OrderProduct>();
    }
}
