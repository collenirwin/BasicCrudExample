using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; }

        /// <summary>
        /// The food group this food belongs to
        /// </summary>
        [Display(Name = "Food Group")]
        public FoodGroup FoodGroup { get; set; }

        /// <summary>
        /// Is this food considered healthy?
        /// </summary>
        [Display(Name = "Healthy")]
        public bool IsHealthy { get; set; }

        /// <summary>
        /// Rating (0 to 10)
        /// </summary>
        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
        public double Rating { get; set; }
    }
}
