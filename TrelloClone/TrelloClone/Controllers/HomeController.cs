using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrelloClone.Models;
using TrelloClone.Services;

namespace TrelloClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login(UserLoginData _userLoginData)
        {
            if (MyAppContext.getUserData() == null &&
                _userLoginData.email !=null &&
                _userLoginData.password != null
                )
            {
                
                string email = _userLoginData.email;
                string password = _userLoginData.password;

                UserAuthController userAuthController = new UserAuthController();
                userAuthController.LoginUser(email, password);

                if (MyAppContext.getUserData() == null)
                {
                    return View();
                }
 


                if (MyAppContext.getUserData().token != null)
                {
                    CardController cc = new CardController();
                    cc.GetAllCardsOfUser();
                }

                //todo navigate to dashboard from here
                return Redirect("~/Home/Dashboard");


            }
            return View();
        }

        public IActionResult Registration(UserRegData _userRegData)
        {

            if(_userRegData.email==null||
                _userRegData.password==null||
                _userRegData.passwordConfirm==null||
                _userRegData.password != _userRegData.passwordConfirm)
            {
                ViewData["RegSuccess"] = "";
                return View();
            }


            //TODO proper error messages 
            string email = _userRegData.email;
            string password = _userRegData.password;
            string passwordConfirm = _userRegData.passwordConfirm;


            
            UserAuthController userAuthController = new UserAuthController();
            string success = userAuthController.RegistrationUser(email, password);

            ViewData["RegSuccess"] = success;

            return View();
        }


        public IActionResult Dashboard(UserRegData _userRegData)
        {
            /* //TODO proper error messages 
             string email = _userRegData.email;
             string password = _userRegData.password;
             string passwordConfirm = _userRegData.passwordConfirm;


             UserAuthController userAuthController = new UserAuthController();
             string success = userAuthController.RegistrationUser(email, password);

             ViewData["RegSuccess"] = success;
            */
            CardController CC = new CardController();
            CC.GetAllCardsOfUser();
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
