using Ema.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ema.Data;
using System.Threading;

namespace Ema.Test.Mocks
{
    class MockMovimientoService : IMovimientoService
    {
        internal List<Movimiento> _db = new List<Movimiento>();

        public void Add(Movimiento entity)
        {
            _db.Add(entity);
        }

        public async Task AddAsync(Movimiento entity)
        {
            await Task.Run(() => 
            {
                _db.Add(entity);

            });
        }

        public void Delete(params object[] keys)
        {
            _db.Remove(FindById(keys));
        }

        public async Task DeleteAsync(params object[] keys)
        {
            await Task.Run(()=> {
                _db.Remove(FindById(keys));
            });

        }

        public Movimiento FindById(params object[] keys)
        {
            return _db.Find(m => m.Id == int.Parse(keys[0].ToString()));
        }

        public async Task<Movimiento> FindByIdAsync(params object[] keys)
        {
            return FindById(keys);
        }

        public IEnumerable<Movimiento> GetAll()
        {
            return _db;
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            return _db;
        }

        public void Update(Movimiento entity)
        {
            Delete(entity.Id);

            Add(entity);
        }

        public async Task UpdateAsync(Movimiento entity)
        {
            Delete(entity.Id);

            Add(entity);
        }
    }
}
