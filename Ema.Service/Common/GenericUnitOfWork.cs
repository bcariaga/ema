using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ema.Service
{
    public class GenericUnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : class
    {

        internal DbContext _dbContext;
        
        // Flag: Has Dispose already been called?
        bool disposed = false;

        public GenericUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            // Free any unmanaged objects here.
            disposed = true;
        }
    }
}
