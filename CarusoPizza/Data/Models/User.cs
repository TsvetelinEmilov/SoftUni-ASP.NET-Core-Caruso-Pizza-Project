namespace CarusoPizza.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.User;

    public class User : IdentityUser
    {
        [MaxLength(FirstAndLastNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(FirstAndLastNameMaxLength)]
        public string LastName { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
