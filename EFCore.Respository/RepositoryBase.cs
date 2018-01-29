using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EFCore.Repository.Internals;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class RepositoryBase : IRepository
    {
        #region Private fields

        protected readonly DbContext _context;

        #endregion

        #region Constructor

        public RepositoryBase(DbContext context)
        { 
            _context = context;
        }

        #endregion

        #region Private methods

        private DbSet<T> DbSet<T>() where T : class => _context.Set<T>();

        #endregion

        #region IInternalRepository

        #region Add

        void IInternalRepository.Add<T>(T entity) => _context.Add(entity);

        void IInternalRepository.Add<T>(List<T> entities) => _context.AddRange(entities);

        void IInternalRepository.Add<T>(IEnumerable<T> entities) => _context.AddRange(entities);

        void IInternalRepository.Add<T>(IQueryable<T> entities) => _context.AddRange(entities);

        #endregion

        #region Update

        void IInternalRepository.Update<T>(T entity) => _context.Update(entity);

        void IInternalRepository.Update<T>(List<T> entities) => _context.UpdateRange(entities);

        void IInternalRepository.Update<T>(IEnumerable<T> entities) => _context.UpdateRange(entities);

        void IInternalRepository.Update<T>(IQueryable<T> entities) => _context.UpdateRange(entities);

        #endregion

        #region Remove

        void IInternalRepository.Remove<T>(T entity) => _context.Remove(entity);

        void IInternalRepository.Remove<T>(List<T> entities) => _context.RemoveRange(entities);

        void IInternalRepository.Remove<T>(IEnumerable<T> entities) => _context.RemoveRange(entities);

        void IInternalRepository.Remove<T>(IQueryable<T> entities) => _context.RemoveRange(entities);

        void IInternalRepository.Remove<T>(int id) => _context.Remove(DbSet<T>().Find(id));

        void IInternalRepository.Remove<T>(Expression<Func<T, bool>> predicate) => _context.RemoveRange(DbSet<T>().Where(predicate));

        #endregion

        #endregion

        #region IAsyncRepository

        async Task IInternalRepository.RemoveAsync<T>(Expression<Func<T, bool>> predicate) => _context.RemoveRange(await DbSet<T>().FirstOrDefaultAsync(predicate));

        async Task IInternalRepository.RemoveAsync<T>(int id) => _context.RemoveRange(await DbSet<T>().FindAsync(id));

        Task IInternalRepository.AddAsync<T>(T entity) => DbSet<T>()?.AddAsync(entity);

        Task IInternalRepository.AddAsync<T>(List<T> entities) => DbSet<T>()?.AddRangeAsync(entities);

        Task IInternalRepository.AddAsync<T>(IEnumerable<T> entities) => DbSet<T>()?.AddRangeAsync(entities);

        Task IInternalRepository.AddAsync<T>(IQueryable<T> entities) => DbSet<T>()?.AddRangeAsync(entities);

        #endregion

        #region IUnitOfWork

        int IUnitOfWork.SaveChanges() => _context.SaveChanges();

        Task<int> IUnitOfWork.SaveChangesAsync() => _context.SaveChangesAsync();

        #endregion

        #region IReadOnlyRepository

        T IReadonlyRepository.Find<T>(Expression<Func<T, bool>> predicate) => DbSet<T>()?.FirstOrDefault(predicate);

        T IReadonlyRepository.Find<T>(int id) => DbSet<T>()?.Find(id);

        IEnumerable<T> IReadonlyRepository.AsEnumerable<T>() => DbSet<T>()?.AsEnumerable();

        IQueryable<T> IReadonlyRepository.AsQueryable<T>() => DbSet<T>()?.AsQueryable();

        List<T> IReadonlyRepository.ToList<T>() => DbSet<T>()?.ToList();

        int IReadonlyRepository.Count<T>() => DbSet<T>()?.Count() ?? -1;

        bool IReadonlyRepository.Exists<T>(Expression<Func<T, bool>> predicate) => DbSet<T>()?.Any(predicate) ?? false;

        #endregion

        #region IAsyncReadOnlyRepository

        async Task<IEnumerable<T>> IAsyncReadOnlyRepository.AsEnumerableAsync<T>() => await DbSet<T>().ToListAsync();

        async Task<List<T>> IAsyncReadOnlyRepository.ToListAsync<T>() => await DbSet<T>().ToListAsync();

        Task<T> IAsyncReadOnlyRepository.FindAsync<T>(Expression<Func<T, bool>> predicate) => DbSet<T>()?.FirstOrDefaultAsync(predicate);

        Task<T> IAsyncReadOnlyRepository.FindAsync<T>(int id) => DbSet<T>()?.FindAsync(id);

        Task<int> IAsyncReadOnlyRepository.CountAsync<T>() => DbSet<T>()?.CountAsync();

        Task<bool> IAsyncReadOnlyRepository.ExistsAsync<T>(Expression<Func<T, bool>> predicate) => DbSet<T>()?.AnyAsync(predicate);

        T IReadonlyRepository.First<T>() => DbSet<T>()?.FirstOrDefault();

        IQueryable<T> IReadonlyRepository.Where<T>(Expression<Func<T, bool>> predicate) => DbSet<T>()?.Where(predicate);

        bool IReadonlyRepository.Any<T>(Expression<Func<T, bool>> predicate) => DbSet<T>().Any(predicate);

        int IReadonlyRepository.Count<T>(Expression<Func<T, bool>> predicate) => DbSet<T>()?.Count(predicate) ?? -1;

        Task<T> IAsyncReadOnlyRepository.FirstAsync<T>() => DbSet<T>()?.FirstOrDefaultAsync();

        #endregion
    }
}