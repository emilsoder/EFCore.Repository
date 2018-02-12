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

        public RepositoryBase(DbContext context) => _context = context;

        #endregion

        #region Private methods

        private DbSet<T> DbSet<T>() where T : class => _context.Set<T>();

        #endregion

        #region IInternalRepository

        #region Add

        void IInternalRepository.Add<T>(T entity)
        {
            if (entity == null) throw new Exception("entities cannot be null");
            _context.Add(entity);
        }

        void IInternalRepository.Add<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.AddRange(entities);
        }

        void IInternalRepository.Add<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.AddRange(entities);
        }

        void IInternalRepository.Add<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.AddRange(entities);
        }

        #endregion

        #region Update

        void IInternalRepository.Update<T>(T entity)
        {
            if (entity == null) throw new Exception("entities cannot be null");
            _context.Update(entity);
        }

        void IInternalRepository.Update<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.UpdateRange(entities);
        }

        void IInternalRepository.Update<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.UpdateRange(entities);
        }

        void IInternalRepository.Update<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.UpdateRange(entities);
        }

        #endregion

        #region Remove

        void IInternalRepository.Remove<T>(T entity)
        {
            if (entity == null) throw new Exception("entity cannot be null");
            _context.Remove(entity);
        }

        void IInternalRepository.Remove<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.RemoveRange(entities);
        }

        void IInternalRepository.Remove<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.RemoveRange(entities);
        }

        void IInternalRepository.Remove<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.RemoveRange(entities);
        }

        void IInternalRepository.Remove<T>(int id)
        {
            var entityToRemove = DbSet<T>().Find(id);
            if (entityToRemove == null) return;
            _context.Remove(entityToRemove);
        }

        void IInternalRepository.Remove<T>(Expression<Func<T, bool>> predicate)
        {
            var entitiesToRemove = DbSet<T>().Where(predicate);
            if (!entitiesToRemove.Any()) return;
            _context.RemoveRange(entitiesToRemove);
        }

        #endregion

        #endregion

        #region IAsyncRepository

        async Task IInternalRepository.RemoveAsync<T>(Expression<Func<T, bool>> predicate)
        {
            var entityToRemove = await DbSet<T>().FirstOrDefaultAsync(predicate);
            if (entityToRemove == null) return;
            _context.RemoveRange(entityToRemove);
        }

        async Task IInternalRepository.RemoveAsync<T>(int id)
        {
            var entityToRemove = await DbSet<T>().FindAsync(id);
            if (entityToRemove == null) return;
            _context.RemoveRange(entityToRemove);
        }

        Task IInternalRepository.AddAsync<T>(T entity)
        {
            if (entity == null) throw new Exception("entity cannot be null");
            return DbSet<T>()?.AddAsync(entity);
        }

        Task IInternalRepository.AddAsync<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            return DbSet<T>()?.AddRangeAsync(entities);
        }

        Task IInternalRepository.AddAsync<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            return DbSet<T>()?.AddRangeAsync(entities);
        }

        Task IInternalRepository.AddAsync<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            return DbSet<T>()?.AddRangeAsync(entities);
        }

        #endregion

        #region IUnitOfWork

        int IUnitOfWork.SaveChanges() => _context.SaveChanges();

        Task<int> IUnitOfWork.SaveChangesAsync() => _context.SaveChangesAsync();

        #endregion

        #region IReadOnlyRepository

        T IReadonlyRepository.Find<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.FirstOrDefault(predicate);
        }

        T IReadonlyRepository.Find<T>(int id)
        {
            return DbSet<T>()?.Find(id);
        }

        IEnumerable<T> IReadonlyRepository.AsEnumerable<T>()
        {
            return DbSet<T>()?.AsEnumerable();
        }

        IQueryable<T> IReadonlyRepository.AsQueryable<T>()
        {
            return DbSet<T>()?.AsQueryable();
        }

        List<T> IReadonlyRepository.ToList<T>()
        {
            return DbSet<T>()?.ToList();
        }

        int IReadonlyRepository.Count<T>()
        {
            return DbSet<T>()?.Count() ?? 0;
        }

        bool IReadonlyRepository.Exists<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.Any(predicate) ?? false;
        }

        #endregion

        #region IAsyncReadOnlyRepository

        async Task<IEnumerable<T>> IAsyncReadOnlyRepository.AsEnumerableAsync<T>()
        {
            return await DbSet<T>().ToListAsync();
        }

        Task<List<T>> IAsyncReadOnlyRepository.ToListAsync<T>()
        {
            return DbSet<T>().ToListAsync();
        }

        Task<T> IAsyncReadOnlyRepository.FindAsync<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.FirstOrDefaultAsync(predicate);
        }

        Task<T> IAsyncReadOnlyRepository.FindAsync<T>(int id)
        {
            return DbSet<T>()?.FindAsync(id);
        }

        Task<int> IAsyncReadOnlyRepository.CountAsync<T>()
        {
            return DbSet<T>()?.CountAsync();
        }

        Task<bool> IAsyncReadOnlyRepository.ExistsAsync<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.AnyAsync(predicate);
        }

        T IReadonlyRepository.First<T>()
        {
            return DbSet<T>()?.FirstOrDefault();
        }

        IQueryable<T> IReadonlyRepository.Where<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.Where(predicate);
        }

        bool IReadonlyRepository.Any<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>().Any(predicate);
        }

        int IReadonlyRepository.Count<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.Count(predicate) ?? 0;
        }

        Task<T> IAsyncReadOnlyRepository.FirstAsync<T>()
        {
            return DbSet<T>()?.FirstOrDefaultAsync();
        }

        #endregion
    }
}