using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Data
{
    /// <summary>
    /// Provides a context for accessing the database
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Represents our Foods table
        /// </summary>
        public DbSet<Food> Foods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
