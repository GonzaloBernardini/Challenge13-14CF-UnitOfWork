using Challenge13Kiosco.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class 
    {

        private readonly DbContext _dbContext;

        protected GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
               
        }

        public void Delete(int id)
        {
            T entity = _dbContext.Find<T>(id);
                 _dbContext.Remove(entity); 
        }

        public T Find(int? id)
        {
             return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        //public Add(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    _dbContext.SaveChanges();
        //    return entity;
        //}

        //public Delete (int id)
        //{
        //    T entity = _dbContext.Find<T>(id);
        //       _dbContext.Remove(entity);           
        //}


        //public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        //{
        //    return await _dbContext.Set<T>().Where(predicate);
        //}

        //public async Task<IEnumerable<T>> GetAll()
        //{

        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public void Update(T entity)
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //}

        //public void Save()
        //{
        //    _dbContext.SaveChanges();
        //}


        //public T Add(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    _dbContext.SaveChanges();
        //    return entity;
        //}

        //public T Delete(int id)
        //{
        //    T entity = _dbContext.Find<T>(id);
        //    _dbContext.Remove(entity);
        //    return entity;
        //}

        //public T Get(int id)
        //{
        //    return _dbContext.Set<T>().Find(id);
        //}

        //public List<T> GetAllEntities()
        //{
        //    return _dbContext.Set<T>().ToList();
        //}

        //public T Update(T entity)
        //{
        //    _dbContext.Attach(entity); //traquea una entidad - toman la entidad
        //    _dbContext.Entry(entity).State = EntityState.Modified; //traquea los cambios
        //    _dbContext.SaveChanges();
        //    return entity;
        //}
    }
}
