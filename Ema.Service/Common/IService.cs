using System;
using System.Collections.Generic;
using System.Text;

namespace Ema.Service
{
    public interface IService<T> where T : class
    {
        T FindById(params object[] keys);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(params object[] keys);

    }
}
