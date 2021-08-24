namespace CarusoPizza.Services.Administrator.Models
{
    using System.Collections.Generic;

    public class AdminOrdersQueryServiceModel
    {
        public IEnumerable<AdminOrderServiceModel> Orders { get; set; }
    }
}
