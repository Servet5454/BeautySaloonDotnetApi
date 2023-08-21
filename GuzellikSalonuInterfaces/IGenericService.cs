using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces
{
    public interface IGenericService<T> : IDisposable
    {
        T Add(T entity);

        T Get(int id);

        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate); //dinamic filtreleme ne verirsek ona göre

        bool Remove(int id);
        bool Remove(T entity);
        T Update(T entity);


    }
}
