﻿using DataEntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IStockRepository:IGenericRepository<Stock>
    {
        List<Stock> StockListing(int stockGroupId);
    }
}
