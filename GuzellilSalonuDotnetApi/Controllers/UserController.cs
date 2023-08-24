using BussinesLogicLayer.Abstract;
using BussinesLogicLayer.Security;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using DataEntitiesLayer.EntitiesModel;
using GuzellikSalonuInterfaces.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GuzellilSalonuDotnetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, GuzellikSalonuDbContext context, IEmailService emailService, IConfiguration configuration)
        {
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
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
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> denememailtest()
        {
           await _emailService.SendEmailAsync("halicarnassus33@gmail.com", "Servet", "halicarnassus33@gmail.com", "deneme","testbaşarılımı",false);
            return Ok();

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> TokenUretimi()
        {
          Token token =  TokenHandlerSinifi.CreateToken(_configuration);


            return Ok(token);

        }

    }
}
