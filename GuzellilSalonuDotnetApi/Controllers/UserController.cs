using BussinesLogicLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using EntityLayerNitelikKatmani.Models;
using GuzellikSalonuInterfaces.Abstract;
using GuzellikSalonuInterfaces.Tokens;
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
        private readonly ITokenHandler _tokenHandler;

        public UserController(IUserService userService, GuzellikSalonuDbContext context, IEmailService emailService, IConfiguration configuration, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
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
        public async Task<IActionResult> CreateUser([FromQuery] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incomplete information entry");
            }
            else
            {
                var answer = await _userService.UserDatabaseCheck(model.UserEmail, model.UserPassword);
                if (answer == true)
                {
                    return BadRequest("You Are already registered in the system.");

                }
                else if (model.UserPassword != model.UserPassword2)
                {
                    return BadRequest("Your passwords do not match.");
                }
                else if (answer != true && model.UserPassword == model.UserPassword2)
                {
                    UserModel createdUser = await _userService.CreateUserAsync(model);
                    return Ok(createdUser);
                }
                else
                {
                    return BadRequest("An error occurred during registration.");
                }

            }

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateteUser([FromQuery] UserModel user)
        {
            return Ok(user);
        }
        [HttpDelete]
        [Route("[action]")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromQuery] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incomplete information entry");
            }
            else
            {
                var answer = await _userService.UserDatabaseCheck(model.UserEmail, model.UserPassword);
                if (answer == true)
                {
                    Token token = await _tokenHandler.CreateToken(_configuration);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("An error occurred during the login process.");
                }
            }


        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromQuery] UserModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Incomplete information entry");
            }
            else
            {
                var answer = await _userService.UserDatabaseCheck(model.UserEmail, model.UserPassword);
                if (answer == true)
                {
                    return BadRequest("You Are already registered in the system.");

                }
                else if (model.UserPassword != model.UserPassword2)
                {
                    return BadRequest("Your passwords do not match.");
                }
                else if (answer != true && model.UserPassword == model.UserPassword2)
                {
                    UserModel createdUser = await _userService.CreateUserAsync(model);
                    return Ok(createdUser);
                }
                else
                {
                    return BadRequest("An error occurred during registration.");
                }

            }


        }
    }
}







//[HttpGet]
//[Route("[action]")]
//public async Task<IActionResult> TokenUretimi()
//{
//  Token token =  TokenHandlerSinifi.CreateToken(_configuration);


//    return Ok(token);

//}



//[HttpGet]
//[Route("[action]")]
//public async Task<IActionResult> denememailtest()
//{
//   await _emailService.SendEmailAsync("halicarnassus33@gmail.com", "Servet", "halicarnassus33@gmail.com", "deneme","testbaşarılımı",false);
//    return Ok();

//}