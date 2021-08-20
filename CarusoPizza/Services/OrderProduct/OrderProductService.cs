namespace CarusoPizza.Services.OrderProduct
{
    using CarusoPizza.Data;
    public class OrderProductService : IOrderProductService
    {
        private readonly CarusoPizzaDbContext data;

        public OrderProductService(CarusoPizzaDbContext data)
            => this.data = data;



    }
}
