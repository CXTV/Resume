
using System.Linq.Expressions;

namespace ResumenManagement.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> ListAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SoftDeletable(T entity);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
