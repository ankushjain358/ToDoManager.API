﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.Models;
using ToDoManager.Service;
using ToDoManager.Infrastructure;

namespace ToDoManager.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private ICategoryService _categoryService;


        public AccountController(IAccountService accountService, ICategoryService categoryService)
        {
            _accountService = accountService;
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [Route("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            LoginResponse loginResponse = _accountService.Login(loginModel);

            if (loginResponse == null)
                return ErrorUtility.BadRequest("Invalid Credentials");

            return Ok(loginResponse);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [Route("register")]
        public IActionResult Register(RegistrationModel registrationModel)
        {
            _accountService.RegiterUser(registrationModel, out int userId);

            _categoryService.CreateDefaultCategoriesForNewUser(userId);

            return Ok();
        }
    }
}