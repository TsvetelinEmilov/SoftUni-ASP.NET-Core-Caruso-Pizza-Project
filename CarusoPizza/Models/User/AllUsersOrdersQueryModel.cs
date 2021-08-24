namespace CarusoPizza.Models.User
{
    using CarusoPizza.Services.User.Models;
    using System.Collections.Generic;

    public class AllUsersOrdersQueryModel
    {
        public IEnumerable<UserOrderServiceModel> Orders { get; set; }

    }
}
