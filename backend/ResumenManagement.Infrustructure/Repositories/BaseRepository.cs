using Microsoft.EntityFrameworkCore;
using ResumenManagement.Application.Contracts.Persistance;
using System.Linq.Expressions;

namespace ResumenManagement.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ResumeDbContext _dbContext;

        public BaseRepository(ResumeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate);

        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();

        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            // 如果传入了 includes 参数，动态添加 Include
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();

        }

        public async Task SoftDeletable(T entity)
        {

            var property = typeof(T).GetProperty("IsActive");


            if (property != null && property.PropertyType == typeof(bool))
            {
                property.SetValue(entity, false);
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Entity {typeof(T).Name} does not have an IsActive property.");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }


}


//using System.Linq.Expressions;
//using Microsoft.EntityFrameworkCore;
//using ResumenManagement.Application.Contracts.Persistance;

//namespace ResumenManagement.Infrastructure.Repositories
//{
//    public class BaseRepository<T> : IAsyncRepository<T> where T : class
//    {
//        protected readonly DbContext _context;

//        public BaseRepository(DbContext context)
//        {
//            _context = context;
//        }

//        public async Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null)
//        {
//            var query = _context.Set<T>().AsQueryable();
//            if (includeExpression != null) query = includeExpression(query);
//            return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
//        }

//        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null)
//        {
//            var query = _context.Set<T>().AsQueryable();
//            if (includeExpression != null) query = includeExpression(query);
//            return await query.FirstOrDefaultAsync(predicate);
//        }

//        public async Task<IReadOnlyList<T>> ListAllAsync(Func<IQueryable<T>, IQueryable<T>>? includeExpression = null)
//        {
//            var query = _context.Set<T>().AsQueryable();
//            if (includeExpression != null) query = includeExpression(query);
//            return await query.ToListAsync();
//        }

//        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null)
//        {
//            var query = _context.Set<T>().AsQueryable();
//            if (includeExpression != null) query = includeExpression(query);
//            return await query.Where(predicate).ToListAsync();
//        }

//        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
//        {
//            return await _context.Set<T>().AnyAsync(predicate);
//        }

//        public async Task<T> AddAsync(T entity)
//        {
//            await _context.Set<T>().AddAsync(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }

//        public async Task UpdateAsync(T entity)
//        {
//            _context.Set<T>().Update(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(T entity)
//        {
//            _context.Set<T>().Remove(entity);
//            await _context.SaveChangesAsync();
//        }


//        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
//        {
//            var query = _context.Set<T>().AsQueryable();
//            if (includeExpression != null) query = includeExpression(query);
//            if (orderBy != null) query = orderBy(query);
//            return await query.Where(predicate).ToListAsync();
//        }

//        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size, Func<IQueryable<T>, IQueryable<T>>? includeExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
//        {
//            var query = _context.Set<T>().AsQueryable();
//            if (includeExpression != null) query = includeExpression(query);
//            if (orderBy != null) query = orderBy(query);
//            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
//        }
//    }
//}
