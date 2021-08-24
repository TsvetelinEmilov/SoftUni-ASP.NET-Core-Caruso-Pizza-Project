namespace CarusoPizza.Services.User.Models
{
    using System.Collections.Generic;

    public class OrdersQueryServiceModel
    {
        public IEnumerable<OrderServiceModel> Orders { get; set; }
    }
}
