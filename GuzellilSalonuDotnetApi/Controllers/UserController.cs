using BussinesLogicLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using DataEntitiesLayer.EntitiesModel;
using Microsoft.AspNetCore.Mvc;

namespace GuzellilSalonuDotnetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly GuzellikSalonuDbContext _dbContext;

        public UserController(IUserService userService,GuzellikSalonuDbContext context)
        {
            _userService = userService;
            _dbContext = context;
        }

        /// <summary>
        /// gözükmesini istiyorum
        /// </summary>
        /// <returns></returns>
       
        [HttpGet]
        [Route("[action]")]
        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = await _userService.GetUsersAsync();
            return users;
        }


        [HttpGet]
        [Route("[action]")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<UserModel> CreateUser([FromQuery]UserModel userModel)
        {
            UserModel createdUser = await _userService.CreateUserAsync(userModel);
            return createdUser;
        }

        [HttpPut]
        [Route("[action]")]
        public UserModel UpdateteUser([FromQuery] UserModel user)
        {
            return _userService.UpdateUser(user);
        }
        [HttpDelete]
        [Route("[action]")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }

    }
}
