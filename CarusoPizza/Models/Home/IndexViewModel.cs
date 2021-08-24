namespace CarusoPizza.Models.Home
{
    using CarusoPizza.Services.Home.Models;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public List<ProductIndexServiceModel> Products { get; set; }
    }
}
