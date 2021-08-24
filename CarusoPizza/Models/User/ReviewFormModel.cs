namespace CarusoPizza.Models.User
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Order;
    public class ReviewFormModel
    {
        [Required]
        [StringLength(
            ReviewMaxLength,
            MinimumLength = ReviewMinLength)]
        public string Review { get; init; }
    }
}
