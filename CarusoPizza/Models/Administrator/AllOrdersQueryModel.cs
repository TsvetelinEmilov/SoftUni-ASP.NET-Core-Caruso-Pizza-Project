namespace CarusoPizza.Models.Administrator
{
    using CarusoPizza.Services.Administrator.Models;
    using System.Collections.Generic;

    public class AllOrdersQueryModel
    {
        public IEnumerable<AdminOrderServiceModel> Orders { get; set; }
    }
}
