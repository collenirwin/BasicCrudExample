using BasicCrud.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCrud.Models
{
    /// <summary>
    /// Represents a food
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Unique identifier for this food
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The name of this food
        /// </summary>
        /// <remarks>
        /// Stored in all uppercase - use <see cref="DisplayName"/> for display
        /// </remarks>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        private string _displayName;

        /// <summary>
        /// Capitalized <see cref="Name"/>
        /// </summary>
        /// <remarks>
        /// This value is cached after first access
        /// </remarks>
        [NotMapped]
        [Display(Name = "Name")]
        public string DisplayName
        {
            get => _displayName ?? (_displayName = Name?.Capitalize());
        }

        /// <summary>
        /// The food group this food belongs to
        /// </summary>
        [Required]
        [Display(Name = "Food Group")]
        public FoodGroup FoodGroup { get; set; }

        /// <summary>
        /// Is this food considered healthy?
        /// </summary>
        [Required]
        [Display(Name = "Healthy")]
        public bool IsHealthy { get; set; }

        /// <summary>
        /// Rating (0 to 10)
        /// </summary>
        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
        public double Rating { get; set; }
    }
}
