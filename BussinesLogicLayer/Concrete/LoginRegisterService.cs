using BussinesLogicLayer.Abstract;
using DataEntitiesLayer.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Concrete
{
    public class LoginRegisterService : ILoginRegisterService
    {
        
        public Task<bool> LoginAsync(UserModel model)
        {
            throw new NotImplementedException();
        }
            

        public Task<bool> RegisterAsync(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
