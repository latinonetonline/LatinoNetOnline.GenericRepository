namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepository<TEntity> : IRepositorySync<TEntity>, IRepositoryAsync<TEntity>, IRepositoryReadOnlyBase<TEntity> where TEntity : class
    {


    }
}