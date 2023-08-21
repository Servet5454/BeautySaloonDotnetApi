using BussinesLogicLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using DataEntitiesLayer.EntitiesModel;
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
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.Surname,
                    Color = model.Color,
                    IsOwner = model.IsOwner,

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
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.Surname,
                    Color = model.Color,
                    IsOwner = model.IsOwner,
                };


                context.Users.Update(user);
                context.SaveChanges();
                return model;
            }
        }
    }
}
