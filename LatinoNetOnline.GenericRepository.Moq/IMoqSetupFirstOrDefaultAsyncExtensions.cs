using LatinoNetOnline.GenericRepository.Repositories;
using LatinoNetOnline.GenericRepository.Specifications;

using Moq;
using Moq.Language.Flow;

using System.Linq.Expressions;

namespace LatinoNetOnline.GenericRepository.Moq
{
    public static class IMoqSetupFirstOrDefaultAsyncExtensions
    {
        public static ISetup<IRepository<T>, Task<T?>> Setup_FirstOrDefaultAsync_1<T>(this Mock<IRepository<T>> repository) where T : class
        {
            return repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<T, bool>>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()));
        }

        public static ISetup<IRepository<T>, Task<T?>> Setup_FirstOrDefaultAsync_2<T>(this Mock<IRepository<T>> repository) where T : class
        {
            return repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<T>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()));
        }

        public static ISetup<IRepository<T>, Task<T?>> Setup_FirstOrDefaultAsync_3<T>(this Mock<IRepository<T>> repository) where T : class
        {
            return repository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<T>>(), It.IsAny<IQueryable<T>>(), It.IsAny<CancellationToken>()));
        }
    }
}