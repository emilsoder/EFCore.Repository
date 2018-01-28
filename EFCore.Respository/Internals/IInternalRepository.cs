using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Respository.Internals
{
    /// <summary>
    ///     Data access layer for operations against the CMS Core database
    /// </summary>
    public interface IInternalRepository : IUnitOfWork
    {
        /// <summary>
        ///     Add element to the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entity">The entity to add</param>
        void Add<T>(T entity) where T : class;

        /// <summary>
        ///     Add a range of objects
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities">The entities to add</param>
        void Add<T>(List<T> entities) where T : class;

        /// <summary>
        ///     Add a range of objects
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities">The entities to add</param>
        void Add<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        ///     Add a range of objects
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities">The entities to add</param>
        void Add<T>(IQueryable<T> entities) where T : class;

        /// <summary>
        ///     Remove an element in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entity">The entity to remove</param>
        void Remove<T>(T entity) where T : class;

        /// <summary>
        ///     Removes defined elements in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        void Remove<T>(List<T> entities) where T : class;

        /// <summary>
        ///     Removes defined elements in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        void Remove<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        ///     Removes defined elements in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        void Remove<T>(IQueryable<T> entities) where T : class;

        /// <summary>
        ///     Removes defined elements in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        void Remove<T>(int id) where T : class;

        /// <summary>
        ///     Updates an element in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entity">The entity to update</param>
        void Update<T>(T entity) where T : class;

        /// <summary>
        ///     Update entities in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities"></param>
        void Update<T>(List<T> entities) where T : class;

        /// <summary>
        ///     Update entities in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities"></param>
        void Update<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        ///     Update entities in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities"></param>
        void Update<T>(IQueryable<T> entities) where T : class;

        /// <summary>
        ///     Removes matching element in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="predicate">The predicate to match the entity</param>
        void Remove<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously removes matching elements in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="predicate">The predicate to match the entity</param>
        Task RemoveAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously removes matching elements in the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="id">The entity id</param>
        Task RemoveAsync<T>(int id) where T : class;

        /// <summary>
        ///     Asynchronously adds an element to the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entity">The entity to add</param>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        ///     Asynchronously add a range of elements to the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities">The entities to add</param>
        Task AddAsync<T>(List<T> entities) where T : class;

        /// <summary>
        ///     Asynchronously add a range of elements to the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities">The entities to add</param>
        Task AddAsync<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        ///     Asynchronously add a range of elements to the DbSet of T
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="entities">The entities to add</param>
        Task AddAsync<T>(IQueryable<T> entities) where T : class;
    }
}