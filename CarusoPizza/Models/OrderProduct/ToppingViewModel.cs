﻿namespace CarusoPizza.Models.OrderProduct
{
    public class ToppingViewModel
    {
        public int Id { get; init; }

        public bool IsOrdered { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

    }
}