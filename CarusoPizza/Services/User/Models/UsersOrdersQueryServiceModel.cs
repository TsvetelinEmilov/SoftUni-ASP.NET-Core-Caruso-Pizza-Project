namespace CarusoPizza.Services.User.Models
{
    using System.Collections.Generic;

    public class UsersOrdersQueryServiceModel
    {
        public IEnumerable<UserOrderServiceModel> Orders { get; set; }
    }
}
