﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Models;
using TrelloClone.Services;

namespace TrelloClone.Controllers
{
    public class UserAuthController
    {
        public User LoginUser(string _email, string _password)
        {

            User currentUser = new User();
            using var client = new HttpClient();
            UserLoginData _userLoginData = new UserLoginData();
            _userLoginData.email = _email;
            _userLoginData.password = _password;
            
            var endpoint = new Uri("http://79.172.201.168/Authentication/SignIn");
            var userLoginRequest = JsonConvert.SerializeObject(_userLoginData);
            var payLoad = new StringContent(content:userLoginRequest, encoding:Encoding.UTF8, mediaType:"application/json");
            var result = client.PostAsync(endpoint, payLoad).Result.Content.ReadAsStringAsync().Result;

            currentUser = JsonConvert.DeserializeObject<User>(result);
            MyAppContext.setUserData(currentUser);
            
            return currentUser;
        }

        public string RegistrationUser(string _email, string _password)
        {
            using var client = new HttpClient();
            UserLoginData _userLoginData = new UserLoginData();
            _userLoginData.email = _email;
            _userLoginData.password = _password;

            var endpoint = new Uri("http://79.172.201.168/Authentication/SignUp");
            var userRegRequest = JsonConvert.SerializeObject(_userLoginData);
            var payLoad = new StringContent(content: userRegRequest, encoding: Encoding.UTF8, mediaType: "application/json");
            var result = client.PostAsync(endpoint, payLoad).Result;
            var resultText = result.Content.ReadAsStringAsync().Result;
            var resultCode = result.IsSuccessStatusCode;

            var responseText = resultCode ? "1" : resultText;

            return responseText;
        }
    }
}
