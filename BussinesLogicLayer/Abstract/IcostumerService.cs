using DataEntitiesLayer.Entities;
using DataEntitiesLayer.Entities.Costumers;
using EntityLayerNitelikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Abstract
{
    public interface IcostumerService
    {
        Task<List<Costumer>> GetAllCostumerrAsync();
        Task<CostumerModel> CreateCostumerAsync(CostumerModel model);
    }
}
