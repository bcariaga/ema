using System.Threading.Tasks;

namespace Ema.Service
{
    public interface IUnitOfWork<T> where T : class
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}