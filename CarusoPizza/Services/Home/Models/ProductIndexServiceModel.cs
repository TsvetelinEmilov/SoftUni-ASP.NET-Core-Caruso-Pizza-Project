using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarusoPizza.Services.Home.Models
{
    public class ProductIndexServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public string ImageUrl { get; init; }
    }
}
