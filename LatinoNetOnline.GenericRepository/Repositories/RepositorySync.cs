using LatinoNetOnline.GenericRepository.Specifications;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);

            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);

            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);

            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(bool tracking = true)
        {
            return Query(tracking).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return Query(tracking).Where(expression).ToList();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification, bool tracking = true)
        {
            return Find(specification, Query(tracking));
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification, IQueryable<TEntity> query)
        {
            return _specificationEvaluator.GetQuery(query, specification).ToList();
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return Query(tracking).Where(expression).FirstOrDefault();
        }

        public TEntity? FirstOrDefault(ISpecification<TEntity> specification, bool tracking = true)
        {
            return FirstOrDefault(specification, Query(tracking));
        }

        public TEntity? FirstOrDefault(ISpecification<TEntity> specification, IQueryable<TEntity> query)
        {
            return _specificationEvaluator.GetQuery(query, specification).FirstOrDefault();
        }

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return Query(tracking).Where(expression).SingleOrDefault();
        }

        public TEntity? SingleOrDefault(ISpecification<TEntity> specification, bool tracking = true)
        {
            return SingleOrDefault(specification, Query(tracking));
        }

        public TEntity? SingleOrDefault(ISpecification<TEntity> specification, IQueryable<TEntity> query)
        {
            return _specificationEvaluator.GetQuery(query, specification).SingleOrDefault();
        }

        public bool Any(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return Query(tracking).Where(expression).Any();
        }

        public bool Any(ISpecification<TEntity> specification, bool tracking = true)
        {
            return Any(specification, Query(tracking));
        }

        public bool Any(ISpecification<TEntity> specification, IQueryable<TEntity> query)
        {
            return _specificationEvaluator.GetQuery(query, specification).Any();
        }

        public int Count(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return Query(tracking).Where(expression).Count();
        }

        public int Count(ISpecification<TEntity> specification, bool tracking = true)
        {
            return Count(specification, Query(tracking));
        }

        public int Count(ISpecification<TEntity> specification, IQueryable<TEntity> query)
        {
            return _specificationEvaluator.GetQuery(query, specification).Count();
        }
    }
}
