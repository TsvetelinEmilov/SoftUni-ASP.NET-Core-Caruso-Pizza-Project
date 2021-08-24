namespace CarusoPizza.Services.User
{
    using CarusoPizza.Services.User.Models;

    public interface IUserService
    {
        OrdersQueryServiceModel GetOrders(string userId);
    }
}
