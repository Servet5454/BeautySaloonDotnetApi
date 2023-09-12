using BussinesLogicLayer.Abstract;
using BussinesLogicLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramwork.Context;
using DataEntitiesLayer.Entities;
using DataEntitiesLayer.Entities.Costumers;
using EntityLayerNitelikKatmani.Models;
using GuzellikSalonuInterfaces.Abstract;
using GuzellikSalonuInterfaces.Concrete;
using GuzellikSalonuInterfaces.Email;
using GuzellikSalonuInterfaces.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace GuzellilSalonuDotnetApi.Controllers
{
    //[EnableRateLimiting("ratepolicy")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ITokenHandler _tokenHandler;
        private readonly IcostumerService _costumerService;

        public UserController(IUserService userService, GuzellikSalonuDbContext context, IEmailService emailService, IConfiguration configuration, ITokenHandler tokenHandler, IcostumerService costumerService)
        {
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _costumerService = costumerService;
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
        public async Task<IActionResult> Login(LoginModel model)
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
        public async Task<IActionResult> Register(UserModel model)
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
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> denememailtest()
        {
            try
            {
                //await _emailService.SendEmailAsync("halicarnassus33@gmail.com", "Servet", "halicarnassus33@gmail.com", "deneme", "testbaşarılımı", false);

                MailRequest mailRequest = new MailRequest();
                mailRequest.ToEmail = "halicarnassus33@gmail.com";
                mailRequest.Subject = "Mail Yollanıyor";
                mailRequest.Body = await _emailService.GetHtmlContentAsync();
                await _emailService.SendEmailWithMimeAsync(mailRequest);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<List<Costumer>> GetAllCostumersAsync()
        {
            List<Costumer> costumers = await _costumerService.GetAllCostumerrAsync();
            return costumers;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCostumer(CostumerModel model)
        {

            await _costumerService.CreateCostumerAsync(model);
            return Ok(model);

        }
    }
}

//https://localhost:7137/User/CreateCostumer bu url ile oluşturulacak





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