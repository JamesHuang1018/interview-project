using System.Collections;
using System.Collections.Generic;

namespace Demo.Domain.Interface
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> Get();
        
        T Get(int id);

        bool Create(T entity);

        bool Update(int id, T entity);

        bool Delete(int id);
    }
}