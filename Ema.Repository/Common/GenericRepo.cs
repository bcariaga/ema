using Ema.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ema.Repository
{
    public abstract class GenericRepo<T> : IRepository<T>, IGenericRepo<T> where T : class
    {
        internal EmaContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepo(EmaContext db)
        {
            _dbContext = db;
            _dbSet = _dbContext.Set<T>();
        }

        #region Sync Methods

        public T FindById(params object[] keys) => _dbSet.Find(keys);

        public IEnumerable<T> GetAll() => _dbSet.ToList();


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(params object[] keys)
        {
            //TODO: Ver si corresponde cambiar el estado
            var entity = FindById(keys);

            //var entityType = entity.GetType();

            //entityType.GetProperty("Activo");

            var dbEntry = _dbContext.Entry(entity);

            if (dbEntry.State == EntityState.Detached)
                _dbContext.Attach(entity);

            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Attach(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;

        }
        #endregion

        #region Async Methods

        public async Task<T> FindByIdAsync(params object[] keys) => await _dbSet.FindAsync(keys);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(params object[] keys)
        {
            //TODO: Ver si corresponde cambiar el estado
            var entity = await FindByIdAsync(keys);

            //var entityType = entity.GetType();

            //entityType.GetProperty("Activo");

            var dbEntry = _dbContext.Entry(entity);

            if (dbEntry.State == EntityState.Detached)
                _dbContext.Attach(entity);

            _dbSet.Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Attach(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;

        }

        #endregion
    }
}

  
    
