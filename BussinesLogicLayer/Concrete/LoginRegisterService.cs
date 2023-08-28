using BussinesLogicLayer.Abstract;
using BussinesLogicLayer.ViewModels;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> LoginCheck(UserModel model)
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                var user = context.Users.FirstOrDefaultAsync(p => p.UserPassword == model.UserPassword && p.UserEmail.ToLower().ToString() == model.UserEmail.ToLower().ToString());
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async Task<bool> RegisterAsync(UserModel model)
        {
           
            throw new NotImplementedException();

        }
    }
}
