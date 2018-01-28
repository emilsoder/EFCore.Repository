using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Respository.Internals
{
    public interface IAsyncReadOnlyRepository
    {
        /// <summary>
        ///     Asynchronously finds an elements in the context by predicate expression.
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="predicate">The predicate expression to match elements</param>
        /// <returns>Matched entity or default value (null)</returns>
        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously finds an elements in the context by Id.
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="id">The id of the entity</param>
        /// <returns>Matched entity or default value (null)</returns>
        Task<T> FindAsync<T>(int id) where T : class;

        /// <summary>
        ///     Asynchronous counts all elements in the specified context class
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Number of elements</returns>
        Task<int> CountAsync<T>() where T : class;

        /// <summary>
        ///     Asynchronous checks if entity exists in the context by predicate expression
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Number of elements</returns>
        Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously returns all elements in the specified context class as List
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        Task<List<T>> ToListAsync<T>() where T : class;

        /// <summary>
        ///     Asynchronously returns all elements in the specified context class as Enumerable
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        Task<IEnumerable<T>> AsEnumerableAsync<T>() where T : class;

        Task<T> FirstAsync<T>() where T : class;
    }
}