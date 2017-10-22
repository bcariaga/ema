using System;
using System.Collections.Generic;
using System.Text;
using Ema.Data;
using Microsoft.EntityFrameworkCore;
using Ema.Repository;
using System.Threading.Tasks;

namespace Ema.Service
{
    public class MovimientoService : IMovimientoService
    {

        internal DbContext _dbcontext;
        internal IMovimientoRepository _repository;
        internal IUnitOfWork<Movimiento> _unitOfWork;

        public MovimientoService(EmaContext dbContext)
        {
            _dbcontext = dbContext;
            _repository = new MovimientoRepository(dbContext);
            _unitOfWork = new GenericUnitOfWork<Movimiento>(dbContext);
        }

        public Movimiento FindById(params object[] keys)
        {
            return _repository.FindById(keys);
        }

        public IEnumerable<Movimiento> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(Movimiento entity)
        {
            _repository.Add(entity);

            _unitOfWork.SaveChanges();
        }

        public void Delete(params object[] keys)
        {
            _repository.Delete(keys);

            _unitOfWork.SaveChanges();
        }

        public void Update(Movimiento entity)
        {
            _repository.Update(entity);

            _unitOfWork.SaveChanges();
        }


        public async Task<Movimiento> FindByIdAsync (params object[] keys)
        {
            return await _repository.FindByIdAsync(keys);
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Movimiento entity)
        {
            await _repository.AddAsync(entity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(params object[] keys)
        {
            await _repository.DeleteAsync(keys);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimiento entity)
        {
            await _repository.UpdateAsync(entity);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
