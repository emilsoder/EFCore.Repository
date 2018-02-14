using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Repository.DependencyInjection
{
    /// <summary>
    /// Dependency injection extensions of IServiceCollection for IRepository and DbContext
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Dependency injection of IRepository and RepositoryBase. 
        /// DbContext must be injected before this method is called.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IRepository, RepositoryBase>();
        }

        /// <summary>
        /// Inject repository as Transient and inject the DbContext to be used application-wise.
        /// </summary>
        /// <typeparam name="T">The DbContext to inject</typeparam>
        /// <param name="services">IServiceCollection in ConfigureServices()</param>
        /// <param name="optionsBuilder">DbContext options</param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoryWithDbContext<T>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> optionsBuilder)
            where T : DbContext
        {
            services.AddDbContext<T>(optionsBuilder);
            return services.AddScoped<DbContext>(provider => provider.GetService<T>());
        }

        /// <summary>
        /// Gives global access to DbContext.
        /// AddDbContext(...) must be injected before this method is called
        /// </summary>
        /// <typeparam name="T">DbContext to inject as a scope</typeparam>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddScopedDbContext<T>(this IServiceCollection services) 
            where T : DbContext
        {
            return services.AddScoped<DbContext>(provider => provider.GetService<T>());
        }
    }
}
