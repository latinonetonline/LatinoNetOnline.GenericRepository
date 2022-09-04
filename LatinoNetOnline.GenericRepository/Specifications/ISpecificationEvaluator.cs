using System.Linq;

namespace LatinoNetOnline.GenericRepository.Specifications
{
    public interface ISpecificationEvaluator
    {
        IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification) where TEntity : class;
    }
}