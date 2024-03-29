﻿using ArtOrder03.Core.Constants;
using ArtOrder03.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService service;

        public UserController(
            RoleManager<IdentityRole> _roleManager,
            IUserService _service)
        {
            roleManager = _roleManager;
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
