﻿using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // will execute when user clicks on register button in the view 
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel requestModel)
        {

            // save the user registration information to the database
            // receive the model from view 
            var newUser = await _userService.RegisterUser(requestModel);

            return View();
        }

        // use this action method to dispay empty view
        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel requestModel)
        {
            var user = await _userService.LoginUser(requestModel);
            if(user == null)
            {
                // username/password is wrong 
                // show message to user saying email/password is wrong 

                return View();

            }
            return LocalRedirect("~/");
        }
    }
}
