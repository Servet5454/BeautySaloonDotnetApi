using BussinesLogicLayer.Abstract;
using BussinesLogicLayer.ViewModels;
using DataAccessLayer;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class UserService : IUserService
    {
        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            using (var context = new GuzellikSalonuDbContext())
            {

                User user = new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Color = model.Color,
                    IsOwner = model.IsOwner,
                    UserEmail = model.UserEmail,
                    UserPassword = model.UserPassword,
                    UserPassword2 = model.UserPassword2

                };

                context.Users.Add(user);
                await context.SaveChangesAsync();
                model.Id = user.Id;
                return model;
            }
        }
        public void DeleteUser(int id)
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                var deletedUser = GetUserById(id);
                context.Users.Remove(deletedUser);
                context.SaveChanges();
            }
        }


        public async Task<List<User>> GetUsersAsync()
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                List<User> liste = await context.Users.ToListAsync();
                return liste;
            }
        }

        public User GetUserById(int id)
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                return context.Users.Find(id);
            }

        }

        public UserModel UpdateUser(UserModel model)
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                User user = new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Color = model.Color,
                    IsOwner = model.IsOwner,
                    UserEmail = model.UserEmail,
                    UserName = model.Name,
                    UserPassword =model.UserPassword,
                    UserPassword2 = model.UserPassword2
                };


                context.Users.Update(user);
                context.SaveChanges();
                return model;
            }
        }
        public async Task<bool> UserDatabaseCheck(string email, string password)
        {
            using (var context = new GuzellikSalonuDbContext())
            {
                var user =await context.Users.FirstOrDefaultAsync(p => p.UserPassword == password && p.UserEmail.ToLower() == email.ToLower());
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

       
    }
}
