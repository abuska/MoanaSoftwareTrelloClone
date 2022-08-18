using System.Collections.Generic;
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
        private static List<User> _UserList;
        private static List<Card> _CardList;

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

        public static void setUserList(List<User> UserList)
        {
            _UserList = UserList;
        }
        public static List<User> getUserList()
        {
            return _UserList;
        }

        public static void setCardList(List<Card> CardList)
        {
            _CardList = CardList;
        }
        public static List<Card> getCardList()
        {
            return _CardList;
        }

        public static HttpContext CurrentHttpContext { get { return _httpContextAccessor.HttpContext; } }
    }
}