using DataEntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Abstract
{
    public interface IStokServiceGenericInterFace : IGenericService<Stock>
    {
        List<Stock> StockListing(int stockGroupId);

    }
}
