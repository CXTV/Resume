
using System.Linq.Expressions;

namespace ResumenManagement.Application.Contracts.Persistance
{


    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

        //Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAllAsync(params Expression<Func<T, object>>[] includes);  // 支持Include

        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SoftDeletable(T entity);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}

//using System.Linq.Expressions;

//namespace ResumenManagement.Application.Contracts.Persistance
//{
//    public interface IAsyncRepository<T> where T : class
//    {
//        Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null);
//        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null);

//        Task<IReadOnlyList<T>> ListAllAsync(Func<IQueryable<T>, IQueryable<T>>? includeExpression = null);
//        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null);

//        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
//        Task<T> AddAsync(T entity);
//        Task UpdateAsync(T entity);
//        Task DeleteAsync(T entity);

//        Task<IReadOnlyList<T>> FindAsync(
//            Expression<Func<T, bool>> predicate,
//            Func<IQueryable<T>, IQueryable<T>>? includeExpression = null,
//            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
//        );

//        Task<IReadOnlyList<T>> GetPagedResponseAsync(
//            int page, int size,
//            Func<IQueryable<T>, IQueryable<T>>? includeExpression = null,
//            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
//        );
//    }
//}
