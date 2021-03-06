using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        IEnumerable<T> GetAll();

         T Find(int? id);

         void Save();
         void Add(T entity);
         void Update (T entity);
         void Delete (int id);
    }
}
