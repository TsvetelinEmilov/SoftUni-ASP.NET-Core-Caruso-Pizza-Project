using System.Collections.Generic;

namespace CarusoPizza.Models.Administrator
{
    public class OrderListingModel
    {
        public IEnumerable<OrderViewModel> Order { get; set; }
    }
}
