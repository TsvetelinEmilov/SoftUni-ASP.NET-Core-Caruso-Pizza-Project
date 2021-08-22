namespace CarusoPizza.Services.Products.Modelis
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public bool IsStopped { get; set; }

        public int CategoryId { get; set; }
    }
}
