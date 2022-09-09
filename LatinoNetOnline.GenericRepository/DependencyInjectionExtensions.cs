using LatinoNetOnline.GenericRepository.Repositories;
using LatinoNetOnline.GenericRepository.Specifications;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace LatinoNetOnline.GenericRepository
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            PropertyInfo[] properties = typeof(TContext).GetProperties();

            IEnumerable<Type> propertiesTypes = properties.Select(x => x.PropertyType).Where(x => x.Name == typeof(DbSet<>).Name && x.Namespace == "Microsoft.EntityFrameworkCore");

            services.AddScoped<ISpecificationEvaluator, SpecificationEvaluator>();


            foreach (Type property in propertiesTypes)
            {
                Type entity = property.GetGenericArguments().First();

                Type repositoryInterfaceType = typeof(IRepository<>).MakeGenericType(entity);

                Type repositoryAsyncInterfaceType = typeof(IRepositoryAsync<>).MakeGenericType(entity);

                Type repositorySyncInterfaceType = typeof(IRepositorySync<>).MakeGenericType(entity);

                Type repositoryReadOnlyAsyncInterfaceType = typeof(IRepositoryReadOnlyAsync<>).MakeGenericType(entity);

                Type repositoryReadOnlySyncInterfaceType = typeof(IRepositoryReadOnlySync<>).MakeGenericType(entity);

                Type repositoryReadOnlyInterfaceType = typeof(IRepositoryReadOnly<>).MakeGenericType(entity);


                Type repositoryClassType = typeof(Repository<>).MakeGenericType(entity);


                Func<IServiceProvider, object> func = sp =>
                {
                    object evaluator = sp.GetRequiredService<ISpecificationEvaluator>();

                    TContext context = sp.GetRequiredService<TContext>();

                    object? o = Activator.CreateInstance(repositoryClassType, new object[] { context, evaluator });

                    return o;
                };

                services.AddScoped(repositoryInterfaceType, func);
                services.AddScoped(repositoryAsyncInterfaceType, func);
                services.AddScoped(repositorySyncInterfaceType, func);
                services.AddScoped(repositoryReadOnlyAsyncInterfaceType, func);
                services.AddScoped(repositoryReadOnlySyncInterfaceType, func);
                services.AddScoped(repositoryReadOnlyInterfaceType, func);
            }

            return services;
        }
    }

}