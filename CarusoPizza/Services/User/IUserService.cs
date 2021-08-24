namespace CarusoPizza.Services.User
{
    using CarusoPizza.Services.User.Models;

    public interface IUserService
    {
        UsersOrdersQueryServiceModel GetOrders(string userId);
    }
}
