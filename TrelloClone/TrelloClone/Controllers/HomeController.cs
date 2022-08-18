using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrelloClone.Models;

namespace TrelloClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(UserLoginData _userLoginData)
        {
            string email = _userLoginData.email;
            string password = _userLoginData.password;

            //beírta a login adatokat a formba.
            UserAuthController userAuthController = new UserAuthController();
            User CurrentUser = userAuthController.LoginUser(email, password);



            return View();
        }

        public IActionResult Registration(UserRegData _userRegData)
        {
            //TODO proper error messages 
            string email = _userRegData.email;
            string password = _userRegData.password;
            string passwordConfirm = _userRegData.passwordConfirm;

            UserAuthController userAuthController = new UserAuthController();
            string success = userAuthController.RegistrationUser(email, password);

            ViewData["RegSuccess"] = success;

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
