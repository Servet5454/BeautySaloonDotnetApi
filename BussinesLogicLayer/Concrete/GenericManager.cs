using DataAccessLayer.Abstract;
using GuzellikSalonuInterfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Concrete
{
    public abstract class GenericManager<T> : IGenericService<T> where T : class
    {
      private readonly  IGenericRepository<T> genericRepository;

        protected GenericManager(IGenericRepository<T> genericRepository)//this consructerlar  arasında veri yollamak için kullanılır...
        {
            this.genericRepository = genericRepository;
        }

        public T Add(T entity)
        {
           return genericRepository.Add(entity);
        }

        public void Dispose()//garbage collectora mudahale ettim
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)//burayla birlikte
        {
            if (disposing)
            {
                genericRepository.Dispose();
            }
        }

        public T Get(int id)
        {
           return genericRepository.Get(id);
        }

        public List<T> GetAll()
        {
           return genericRepository.GetAll();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
           return genericRepository.GetAll(predicate);
        }

        public bool Remove(int id)
        {
            return  genericRepository.Remove(id);
        }

        public bool Remove(T entity)
        {
            return genericRepository.Remove(entity);
        }

        public T Update(T entity)
        {
            return genericRepository.Update(entity);
        }
    }
}
