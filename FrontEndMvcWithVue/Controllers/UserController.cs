﻿using Microsoft.AspNetCore.Mvc;

namespace FrontEndMvcWithVue.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
