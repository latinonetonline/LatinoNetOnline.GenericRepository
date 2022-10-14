using LatinoNetOnline.GenericRepository.Specifications;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepositoryReadOnlyAsync<TEntity> : IRepositoryReadOnlyBase<TEntity> where TEntity : class
    {

        #region GetAllAsync

        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        #endregion

        #region FindAsync

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, bool tracking, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);


        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        #endregion

        #region FirstOrDefaultAsync
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool tracking, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, bool tracking, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        #endregion

        #region SingleOrDefaultAsync

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool tracking, CancellationToken cancellationToken = default);
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, bool tracking, CancellationToken cancellationToken = default);
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);


        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        #endregion

        #region AnyAsync

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);

        #endregion

        #region CountAsync

        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default);

        #endregion
    }
}
