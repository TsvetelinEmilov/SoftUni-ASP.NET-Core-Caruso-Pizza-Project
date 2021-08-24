namespace CarusoPizza.Services.Administrator
{
    using CarusoPizza.Services.Administrator.Models;

    public interface IAdministratorService
    {
        AdminOrdersQueryServiceModel GetOrders();

        AdminCurrentOrderServiceModel FindOrderById(int orderId);
    }
}
