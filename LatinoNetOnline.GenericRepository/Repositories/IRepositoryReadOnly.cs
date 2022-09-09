

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepositoryReadOnly<TEntity> : IRepositoryReadOnlySync<TEntity>, IRepositoryReadOnlyAsync<TEntity> where TEntity : class
    {

    }
}
