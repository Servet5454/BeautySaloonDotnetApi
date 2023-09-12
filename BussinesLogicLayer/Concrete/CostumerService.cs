using BussinesLogicLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using DataEntitiesLayer.Entities.Costumers;
using EntityLayerNitelikKatmani.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Concrete
{
    public class CostumerService : IcostumerService
    {
        public async Task<CostumerModel> CreateCostumerAsync(CostumerModel model)
        {
            using (var context = new GuzellikSalonuDbContext())
            {

                Costumer costumer = new Costumer()
                {
                   CostumerName =model.CostumerName,
                   CostumerSurname =model.CostumerSurname,
                   CostumerEmail =model.CostumerEmail,
                   CostumerPhone =model.CostumerPhone,
                   Balance =model.Balance,
                   Point =model.Point,

                };

                await context.Costumers.AddAsync(costumer);
                await context.SaveChangesAsync();
                model.Id = costumer.Id;
                return model;
            }
        }

        public async Task<List<Costumer>> GetAllCostumerrAsync()//TODO Costumermodel'e Çevrilecek
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                List<Costumer> liste =await context.Costumers.ToListAsync();
                return liste;
            }
        }
    }
}
