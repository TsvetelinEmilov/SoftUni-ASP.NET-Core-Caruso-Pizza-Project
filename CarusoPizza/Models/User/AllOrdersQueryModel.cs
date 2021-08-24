namespace CarusoPizza.Models.User
{
    using CarusoPizza.Services.User.Models;
    using System.Collections.Generic;

    public class AllOrdersQueryModel
    {
        public IEnumerable<OrderServiceModel> Orders { get; set; }

    }
}
