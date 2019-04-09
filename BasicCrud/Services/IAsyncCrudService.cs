using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicCrud.Services
{
    /// <summary>
    /// Provides a contract for basic CRUD operations
    /// </summary>
    /// <typeparam name="TModel">The database model we're working with</typeparam>
    /// <typeparam name="TIdentifier">The model's primary key type</typeparam>
    interface IAsyncCrudService<TModel, TIdentifier>
    {
        Task AddAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task<TModel> GetByIdAsync(TIdentifier id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task DeleteAsync(TIdentifier id);
    }
}
