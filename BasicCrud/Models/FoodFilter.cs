using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Models
{
    /// <summary>
    /// A filter specification for <see cref="Food"/> objects
    /// </summary>
    public class FoodFilter
    {
        /// <summary>
        /// Optional partial or whole name of the food to look for
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Optional food group to match
        /// </summary>
        [Display(Name = "Food Group")]
        public FoodGroup? FoodGroup { get; set; }

        /// <summary>
        /// Optional healthy value to match
        /// </summary>
        [Display(Name = "Healthy")]
        public bool? IsHealthy { get; set; }

        /// <summary>
        /// Optional minumum rating to match
        /// </summary>
        [Display(Name = "Min Rating")]
        [Range(0.0, 10.0, ErrorMessage = "Min rating must be between 0 and 10.")]
        public double MinRating { get; set; } = 0.0;

        /// <summary>
        /// Optional maximum rating to match
        /// </summary>
        [Display(Name = "Max Rating")]
        [Range(0.0, 10.0, ErrorMessage = "Max rating must be between 0 and 10.")]
        public double MaxRating { get; set; } = 10.0;
    }
}
