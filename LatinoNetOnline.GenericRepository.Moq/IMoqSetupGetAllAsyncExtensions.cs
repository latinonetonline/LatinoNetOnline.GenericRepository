using LatinoNetOnline.GenericRepository.Repositories;

using Moq;
using Moq.Language.Flow;

namespace LatinoNetOnline.GenericRepository.Moq
{
    public static class IMoqSetupGetAllAsyncExtensions
    {
        public static ISetup<IRepository<T>, Task<IEnumerable<T>>> Setup_GetAllAsync<T>(this Mock<IRepository<T>> repository) where T : class
        {
            return repository.Setup(r => r.GetAllAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()));
        }

    }
}