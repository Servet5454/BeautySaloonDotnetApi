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
        public List<User> GetUsers()
        {
            return _userService.GetAllUser();
        }
        [HttpGet]
        [Route("[action]")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        [Route("[action]")]
        public UserModel CreateUser([FromQuery]UserModel userModel)
        {
            return _userService.CreateUser(userModel);
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
