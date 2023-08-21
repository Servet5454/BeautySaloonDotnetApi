using DataAccessLayer.Abstract;
using DataEntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramwork.Repository
{
    public class EfStockRepository:EfGenericRepository<Stock>,IStockRepository
    {


    }
}
