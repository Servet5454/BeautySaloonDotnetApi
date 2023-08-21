using DataAccessLayer.Abstract;
using DataEntitiesLayer.Entities;
using GuzellikSalonuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Concrete
{
    public class StockManager:GenericManager<Stock>,IStokServiceGenericInterFace
    {
      private readonly IStockRepository stockRepository;

        public StockManager(IStockRepository stockRepository) : base(stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public List<Stock> StockListing(int stockGroupId)
        {
            return stockRepository.StockListing(stockGroupId);
        }
    }
}
