using System.Threading.Tasks;

namespace EFCore.Repository.Internals
{
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Synchronously calls SaveChanges to DbContext.
        ///     Saves the tracked changes in the context.
        /// </summary>
        /// <returns>Number of rows affected.</returns>
        int SaveChanges();

        /// <summary>
        ///     Asynchronously calls SaveChanges to DbContext.
        ///     Saves the tracked changes in the context.
        /// </summary>
        /// <returns>Number of rows affected.</returns>
        Task<int> SaveChangesAsync();
    }
}