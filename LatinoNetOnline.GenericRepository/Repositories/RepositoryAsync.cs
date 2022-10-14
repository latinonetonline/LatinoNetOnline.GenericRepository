using LatinoNetOnline.GenericRepository.Specifications;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly ISpecificationEvaluator _specificationEvaluator;
        public Repository(DbContext context, ISpecificationEvaluator specificationEvaluator)
        {
            _context = context;
            _specificationEvaluator = specificationEvaluator;
        }
        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Add(entity);

            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().AddRange(entities);

            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            return _context.SaveChangesAsync(cancellationToken);
        }

        #region FindAsync

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking, CancellationToken cancellationToken = default)
        {
            return await Query(tracking).Where(expression).ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, bool tracking, CancellationToken cancellationToken = default)
        {
            return FindAsync(specification, Query(tracking), cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return await _specificationEvaluator.GetQuery(query, specification).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await Query(true).Where(expression).ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return FindAsync(specification, Query(true), cancellationToken);
        }

        #endregion

        public IQueryable<TEntity> Query(bool tracking = true)
        {

            var query = _context.Set<TEntity>().AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);

            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().RemoveRange(entities);

            return _context.SaveChangesAsync(cancellationToken);
        }

        #region FirstOrDefaultAsync

        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool tracking, CancellationToken cancellationToken = default)
        {
            return Query(tracking).Where(expression).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, bool tracking, CancellationToken cancellationToken = default)
        {
            return FirstOrDefaultAsync(specification, Query(tracking), cancellationToken);
        }

        public Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return _specificationEvaluator.GetQuery(query, specification).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return Query(true).Where(expression).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return FirstOrDefaultAsync(specification, Query(true), cancellationToken);
        }

        #endregion

        #region SingleOrDefaultAsync

        public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool tracking, CancellationToken cancellationToken = default)
        {
            return Query(tracking).Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, bool tracking, CancellationToken cancellationToken = default)
        {
            return SingleOrDefaultAsync(specification, Query(tracking), cancellationToken);
        }

        public Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return _specificationEvaluator.GetQuery(query, specification).SingleOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return Query(true).Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return SingleOrDefaultAsync(specification, Query(true), cancellationToken);
        }

        #endregion

        #region AnyAsync

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return Query(false).Where(expression).AnyAsync(cancellationToken);
        }

        public Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return AnyAsync(specification, Query(false), cancellationToken);
        }

        public Task<bool> AnyAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return _specificationEvaluator.GetQuery(query, specification).AnyAsync(cancellationToken);
        }

        #endregion

        #region CountAsync
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return Query(false).Where(expression).CountAsync(cancellationToken);
        }

        public Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return CountAsync(specification, Query(false), cancellationToken);
        }

        public Task<int> CountAsync(ISpecification<TEntity> specification, IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return _specificationEvaluator.GetQuery(query, specification).CountAsync(cancellationToken);
        }

        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking, CancellationToken cancellationToken = default)
        {
            return await Query(tracking).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Query(false).ToListAsync(cancellationToken);
        }

        #endregion
    }
}