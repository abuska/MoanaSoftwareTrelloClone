using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrelloClone.Models;

namespace TrelloClone.Services
{
    public static class MyAppContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        private static User _CurrentUser;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            
        }
        public static void setUserData(User _user)
        {
            _CurrentUser = _user;
        }
        public static User getUserData()
        {
            return _CurrentUser;
        }


        public static HttpContext CurrentHttpContext { get { return _httpContextAccessor.HttpContext; } }
    }
}