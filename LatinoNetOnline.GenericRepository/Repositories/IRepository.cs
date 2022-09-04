using LatinoNetOnline.GenericRepository.Specifications;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(bool tracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, bool tracking = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);


        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, bool tracking = true, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);



        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, CancellationToken cancellationToken = default);
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, bool tracking = true, CancellationToken cancellationToken = default);
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);


        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(ISpecification<TEntity> specification, bool tracking = true, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);



        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<TEntity> specification, bool tracking = true, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);





        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}