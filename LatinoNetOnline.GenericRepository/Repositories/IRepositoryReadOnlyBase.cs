using System.Linq;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepositoryReadOnlyBase<out TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(bool tracking = true);

    }
}
