using System.Collections.Generic;
using System.Threading.Tasks;
using Ema.Data;

namespace Ema.Service
{
    public interface IMovimientoService
    {
        void Add(Movimiento entity);
        Task AddAsync(Movimiento entity);
        void Delete(params object[] keys);
        Task DeleteAsync(params object[] keys);
        Movimiento FindById(params object[] keys);
        Task<Movimiento> FindByIdAsync(params object[] keys);
        IEnumerable<Movimiento> GetAll();
        Task<IEnumerable<Movimiento>> GetAllAsync();
        void Update(Movimiento entity);
        Task UpdateAsync(Movimiento entity);
    }
}