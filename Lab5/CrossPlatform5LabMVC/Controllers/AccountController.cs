﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CrossPlatform5LabMVC.ViewModels;
using System.Linq;
using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using System;


namespace CrossPlatform5LabMVC.Controllers
{
    public class AccountController : Controller
    {
        public async Task Login(string returnUrl = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        public IActionResult Profile()
        {
            ////var userMetadataClaim = User.FindFirst("user_metadata");
            ////var userMetadataString = userMetadataClaim.Value;
            ////var userMetadata = JObject.Parse(userMetadataString);
            Console.WriteLine("Test");
            Console.WriteLine(User.Claims.FirstOrDefault(c => c.Type == "phone_number")?.Value);
            Console.WriteLine(User);
            //var phoneValue = userMetadata["phone"]?.ToString();
            return View(new UserProfileViewModel()
            {
                Name = User.Identity.Name,
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                Number = User.Claims.FirstOrDefault(c => c.Type == "phone")?.Value

                //Number = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.Number)?.Value
                //Number=User.Claims.
                //Number = User.Claims.First("user_metadata.phone"),
                //Number = phoneValue
            })
                ; 
        }


        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
