using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary5CrossPlatform;


namespace CrossPlatform5LabMVC.Controllers
{
    public class LabsController : Controller
    {
        [Authorize]
        public IActionResult Lab1()
        {
            return View();
        }

        [Authorize]
        public IActionResult Lab2()
        {
            return View();
        }

        [Authorize]
        public IActionResult Lab3()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult DoLab1(int input1)
        {
            string input = input1.ToString();
            TempData["result"] = LabRunner.Run(1, input);
            return View("Lab1");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DoLab2(string input2)
        {

            TempData["result"] = LabRunner.Run(2, input2);
            return View("Lab2");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DoLab3(string input3)
        {
            TempData["result"] = LabRunner.Run(3, input3);
            return View("Lab3");

        }

    }
}
