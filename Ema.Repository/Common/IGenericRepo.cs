using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ema.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(params object[] keys);
        Task DeleteAsync(params object[] keys);
        T FindById(params object[] keys);
        Task<T> FindByIdAsync(params object[] keys);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        Task UpdateAsync(T entity);
    }
}