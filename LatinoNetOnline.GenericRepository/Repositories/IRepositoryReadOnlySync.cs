using LatinoNetOnline.GenericRepository.Specifications;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepositoryReadOnlySync<TEntity>: IRepositoryReadOnlyBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(bool tracking = true);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool tracking = true);
        IEnumerable<TEntity> Find(ISpecification<TEntity> specification, bool tracking = true);
        IEnumerable<TEntity> Find(ISpecification<TEntity> specification, IQueryable<TEntity> query);


        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression, bool tracking = true);
        TEntity? FirstOrDefault(ISpecification<TEntity> specification, bool tracking = true);
        TEntity? FirstOrDefault(ISpecification<TEntity> specification, IQueryable<TEntity> query);



        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> expression, bool tracking = true);
        TEntity? SingleOrDefault(ISpecification<TEntity> specification, bool tracking = true);
        TEntity? SingleOrDefault(ISpecification<TEntity> specification, IQueryable<TEntity> query);


        bool Any(Expression<Func<TEntity, bool>> expression, bool tracking = true);
        bool Any(ISpecification<TEntity> specification, bool tracking = true);
        bool Any(ISpecification<TEntity> specification, IQueryable<TEntity> query);



        int Count(Expression<Func<TEntity, bool>> expression, bool tracking = true);
        int Count(ISpecification<TEntity> specification, bool tracking = true);
        int Count(ISpecification<TEntity> specification, IQueryable<TEntity> query);
    }
}
