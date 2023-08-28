using BussinesLogicLayer.ViewModels;
using DataEntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer.Abstract
{
    public interface IUserService
    {
        Task<bool> UserDatabaseCheck(string email, string password);

        Task<List<User>> GetUsersAsync();


        User GetUserById(int id);


        Task<UserModel> CreateUserAsync(UserModel model);


        UserModel UpdateUser(UserModel model);



        void DeleteUser(int id);


    }
}
