﻿using AspnetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreIdentityApp.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public MemberController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

            //return RedirectToAction("Index", "Home");
        }
    }
}
