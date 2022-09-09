using System.Collections.Generic;

namespace LatinoNetOnline.GenericRepository.Repositories
{
    public interface IRepositorySync<TEntity> : IRepositoryReadOnlySync<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
