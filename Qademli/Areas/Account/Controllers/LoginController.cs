﻿using Microsoft.AspNetCore.Mvc;

namespace Qademli.Areas.Account.Controllers
{
    [Area("Account")]
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult UpdateAccount()
        {
            return View();
        }
        public IActionResult AdminAccount()
        {
            return View();
        }

        public IActionResult Unauthorize()
        {
            return View();
        }

   
    }
}