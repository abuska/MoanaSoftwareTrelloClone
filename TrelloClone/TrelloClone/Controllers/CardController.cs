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

        public Card GetCardDetails(string _cardId)
        {
            var endpoint = new Uri("http://79.172.201.168/Cards/GetById?"+_cardId);
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                using var client = new HttpClient();
                string currentUserToken = MyAppContext.getUserData().token;
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                Card card = JsonConvert.DeserializeObject<Card>(result);

                return card;
            }
        }

        public void CreateCard(string _title, string _description)
        {
            using var client = new HttpClient();
            Card newCard = new Card();
            newCard.title = _title;
            newCard.description = _description;

            var endpoint = new Uri("http://79.172.201.168/Cards/Add");
            var newCardRequest = JsonConvert.SerializeObject(newCard);
            var payLoad = new StringContent(content: newCardRequest, encoding: Encoding.UTF8, mediaType: "application/json");
            var result = client.PostAsync(endpoint, payLoad).Result;
            var resultText = result.Content.ReadAsStringAsync().Result;
            var resultCode = result.IsSuccessStatusCode;

            var responseText = resultCode ? "1" : resultText;

            GetAllCardsOfUser();
        }

        public void UpdateCard(string _id, string _title, string _description, int _status, int _position, string _asigneeId)
        {
            using var client = new HttpClient();
            Card newCard = new Card();
            newCard.id = _id;
            newCard.title = _title;
            newCard.description = _description;
            newCard.status = _status;
            newCard.position = _position;
            newCard.asigneeId = _asigneeId;

            var endpoint = new Uri("http://79.172.201.168/Cards/Update");
            var cardUpdateRequest = JsonConvert.SerializeObject(newCard);
            var payLoad = new StringContent(content: cardUpdateRequest, encoding: Encoding.UTF8, mediaType: "application/json");
            var result = client.PutAsync(endpoint, payLoad).Result;
            var resultText = result.Content.ReadAsStringAsync().Result;
            var resultCode = result.IsSuccessStatusCode;

            var responseText = resultCode ? "1" : resultText;

            GetAllCardsOfUser();
        }
        public void DeleteCard(string _id)
        {
            using var client = new HttpClient();
            Card deleteCard = new Card();
            deleteCard.id = _id;

            var endpoint = new Uri("http://79.172.201.168/Cards/Delete");
            var deleteCardRequest = JsonConvert.SerializeObject(deleteCard);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = endpoint,
                Content = new StringContent(deleteCardRequest, Encoding.UTF8, "application/json")
            };
            var result = client.SendAsync(request).Result;
            var resultText = result.Content.ReadAsStringAsync().Result;
            var resultCode = result.IsSuccessStatusCode;

            var responseText = resultCode ? "1" : resultText;

            GetAllCardsOfUser();
        }





    }
}
