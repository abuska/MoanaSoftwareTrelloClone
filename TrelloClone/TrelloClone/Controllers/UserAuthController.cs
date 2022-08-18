using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Models;

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
                return currentUser;
        }
    }
}
