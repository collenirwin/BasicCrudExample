using System.Collections.Generic;

namespace BasicCrud.Models
{
    /// <summary>
    /// Contains information needed in the View page
    /// </summary>
    public class ViewViewModel
    {
        /// <summary>
        /// Specifies how to filter the foods
        /// </summary>
        public FoodFilter Filter { get; set; }

        /// <summary>
        /// Foods that match the filter
        /// </summary>
        public IEnumerable<Food> Foods { get; set; }

        public ViewViewModel()
        {
            Filter = new FoodFilter();
        }
    }
}
