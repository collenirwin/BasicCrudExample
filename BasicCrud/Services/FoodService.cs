using BasicCrud.Data;
using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasicCrud.Services
{
    /// <summary>
    /// Provides methods for querying the Food table of the database
    /// </summary>
    public class FoodService
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// This should only be called by via automatic DI
        /// </summary>
        public FoodService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a food to the database
        /// </summary>
        /// <param name="model">Food to add</param>
        public async Task AddAsync(Food model)
        {
            _context.Foods.Add(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a food from the database
        /// </summary>
        /// <param name="id">Id of the food to delete</param>
        public async Task DeleteAsync(string id)
        {
            var food = await GetByIdAsync(id);

            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all foods from the database
        /// </summary>
        /// <returns>A collection containing all of our foods</returns>
        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        /// <summary>
        /// Get a particular food by its Id
        /// </summary>
        /// <param name="id">Id of the food</param>
        /// <returns>The food with the specified Id, or null if not found</returns>
        public async Task<Food> GetByIdAsync(string id)
        {
            return await _context.Foods.SingleOrDefaultAsync(food => food.Id == id);
        }

        /// <summary>
        /// Get all foods that match the given filter, optionally ordered by the specified expression
        /// </summary>
        /// <typeparam name="TKey">The property to order by</typeparam>
        /// <param name="filter">Filter specification object</param>
        /// <param name="orderBy">Key selector expression to determine the property to order by</param>
        /// <param name="ascendingOrder">Should we sort in ascendin order?</param>
        /// <returns>A collection containing all foods that match the filter</returns>
        public async Task<IEnumerable<Food>> GetFilteredAsync<TKey>(FoodFilter filter,
            Expression<Func<Food, TKey>> orderBy = null, bool ascendingOrder = true)
        {
            var query = _context.Foods.AsQueryable();

            if (filter.Name != null)
            {
                query = query.Where(food => food.Name.Contains(filter.Name));
            }

            if (filter.FoodGroup != null)
            {
                query = query.Where(food => food.FoodGroup == filter.FoodGroup);
            }

            if (filter.IsHealthy != null)
            {
                query = query.Where(food => food.IsHealthy == filter.IsHealthy);
            }

            if (filter.MinRating != 0.0 || filter.MaxRating != 10.0)
            {
                query = query.Where(food => food.Rating >= filter.MinRating && food.Rating <= filter.MaxRating);
            }

            if (orderBy != null)
            {
                query = ascendingOrder
                    ? query.OrderBy(orderBy)
                    : query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Update the food with the passed food's Id to the passed food's values
        /// </summary>
        /// <param name="food">Food we're updating to</param>
        public async Task UpdateAsync(Food food)
        {
            var oldFood = await GetByIdAsync(food.Id);

            if (oldFood == null)
            {
                throw new InvalidOperationException("Food to update does not exist");
            }

            _context.Entry(oldFood).CurrentValues.SetValues(food);
            await _context.SaveChangesAsync();
        }
    }
}
