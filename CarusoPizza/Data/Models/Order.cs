namespace CarusoPizza.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants.Order;

    public class Order
    {
        public int Id { get; init; }

        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SumPrice { get; init; }

        public string CreatorId { get; set; }

        public User Creator { get; init; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; init; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; init; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email{ get; init; }

        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; init; }

        [MaxLength(DistrictMaxLength)]
        public string District { get; init; }

        [Required]
        [MaxLength(StreetAndNumberMaxLength)]
        public string StreetAndNumber { get; init; }

        [MaxLength(NoteMaxLength)]
        public string Note { get; init; }

        [MaxLength(ReviewMaxLength)]
        public string Review { get; set; }

        public IEnumerable<OrderProduct> Products { get; set; }
    }
}
