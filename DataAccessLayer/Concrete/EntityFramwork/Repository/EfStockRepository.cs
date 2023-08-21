using DataAccessLayer.Abstract;
using DataEntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramwork.Repository
{
    public class EfStockRepository : EfGenericRepository<Stock>, IStockRepository
    {
        public List<Stock> StockListing(int stockGroupId)
        {
            return context.Stocks.Where(p=>p.StockGroupId == stockGroupId).ToList();
        }
    }
}
