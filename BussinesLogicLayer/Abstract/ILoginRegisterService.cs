
using EntityLayerNitelikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Abstract
{
    public interface ILoginRegisterService
    {
        Task<bool> RegisterAsync(UserModel model);
        Task<bool> LoginAsync(UserModel model);
        Task<bool> LoginCheck(UserModel model);
    }
}
