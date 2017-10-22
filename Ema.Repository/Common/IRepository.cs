using System;
using System.Collections.Generic;
using System.Text;

namespace Ema.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(params object[] keys);

        T FindById(params object[] keys);

        IEnumerable<T> GetAll();
    }
}
