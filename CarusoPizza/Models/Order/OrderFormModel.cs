namespace CarusoPizza.Models.Order
{
    using CarusoPizza.Services.OrderProduct.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Order;

    public class OrderFormModel
    {
        public decimal SumPrice { get; init; }

        [Required]
        [StringLength(
            PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Your phone number")]
        public string PhoneNumber { get; init; }

        [Required]
        [StringLength(
            FullNameMaxLength,
            MinimumLength = FullNameMinLength)]
        [Display(Name = "First and last name")]
        public string FullName { get; init; }

        [Required]
        [StringLength(
            EmailMaxLength,
            MinimumLength = EmailMinLength)]
        [RegularExpression(EmailRegularExpression)]
        [Display(Name = "E-mail address")]
        public string Email { get; init; }

        [Required]
        [StringLength(
            CityMaxLength,
            MinimumLength = CityMinLength)]
        [Display(Name = "City")]
        public string City { get; init; }

        [StringLength(
            DistrictMaxLength,
            MinimumLength = DistrictMinLength)]
        [Display(Name = "District (optional)")]
        public string District { get; init; }

        [Required]
        [StringLength(
            StreetAndNumberMaxLength,
            MinimumLength = StreetAndNumberMinLength)]
        [Display(Name = "Street name and number")]
        public string StreetAndNumber { get; init; }

        [StringLength(
            NoteMaxLength,
            MinimumLength = NoteMinLength)]
        [Display(Name = "Note (optional)")]
        public string Note { get; init; }

        public IEnumerable<OrderProductServiceModel> Products { get; set; }

    }
}
