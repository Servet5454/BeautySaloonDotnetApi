using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramwork.Repository
{
    public abstract class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GuzellikSalonuDbContext  context;

      

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                context.Dispose();
            }
        }

        public T Get(int id)
        {
            var entity = context.Set<T>().Find(id);
            context.Entry(entity).State = EntityState.Deleted;
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().AsNoTracking().ToList();//change Tracker'ı Kapattım
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public bool Remove(int id)
        {
            return Remove(Get(id));
        }

        public bool Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges() > 0;
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
