using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TrelloClone.Models;
using TrelloClone.Services;

namespace TrelloClone.Controllers
{
    public class CardController
    {
        public void GetAllCardsOfUser()
        {

            var endpoint = new Uri("http://79.172.201.168/Cards/GetAll");
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {

                using var client = new HttpClient();
                string currentUserToken = MyAppContext.getUserData().token;
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(result);

                MyAppContext.setCardList(cardList);
            }
        }



     
    }
}
