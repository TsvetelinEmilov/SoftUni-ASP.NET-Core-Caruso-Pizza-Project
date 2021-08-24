namespace CarusoPizza.Services.Order
{
    using CarusoPizza.Services.OrderProduct.Models;
    using System.Collections.Generic;

    public interface IOrderService
    {
        IEnumerable<OrderProductServiceModel> OrderProductsByUser(string userId);

        public int CreateOrder(
            decimal sumPrice,
            string phoneNumber,
            string fullName,
            string email,
            string city,
            string district,
            string streetAndNumber,
            string note,
            IEnumerable<OrderProductServiceModel> orderProducts,
            string userId);

        bool AddReview(int orderId, string review);
    }
}
