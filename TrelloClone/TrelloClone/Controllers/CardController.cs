using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TrelloClone.Models;
using TrelloClone.Services;




namespace TrelloClone.Controllers
{
    public class CardController
    {
        public string GetAllCardsOfUserAPI()
        {
            var endpoint = new Uri("http://79.172.201.168/Cards/GetAll");
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {

                using var client = new HttpClient();
                string currentUserToken = MyAppContext.getUserData().token;
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                return result;
            }
        }

        public void GetAllCardsOfUser()
        {

           var result = GetAllCardsOfUserAPI();

           List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(result);
           MyAppContext.setCardList(cardList);
        }


        public string GetCardDetailsAPI(string _cardId)
        {
            var endpoint = new Uri("http://79.172.201.168/Cards/GetById?id=" + _cardId);
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                using var client = new HttpClient();
                string currentUserToken = MyAppContext.getUserData().token;
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                return result;
            }
        }
        public Card GetCardDetails(string _cardId)
        {
           var result = GetCardDetailsAPI(_cardId);

            Card card = JsonConvert.DeserializeObject<Card>(result);
            return card;
        }


        public string CreateCardAPI(string _title, string _description, int _status)
        {
            using var client = new HttpClient();
            string currentUserToken = MyAppContext.getUserData().token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);
            CardCreateRequestBody newCard = new CardCreateRequestBody();
            newCard.title = _title;
            newCard.description = _description;
            newCard.status = _status;

            var endpoint = new Uri("http://79.172.201.168/Cards/Add");
            var newCardRequest = JsonConvert.SerializeObject(newCard);
            var payLoad = new StringContent(content: newCardRequest, encoding: Encoding.UTF8, mediaType: "application/json");
            var result = client.PostAsync(endpoint, payLoad).Result;
            var resultText = result.Content.ReadAsStringAsync().Result;
            var resultCode = result.IsSuccessStatusCode;

            var responseText = resultCode ? "1" : resultText;
            var allCards = GetAllCardsOfUserAPI();
            List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(allCards);
            Card LastCard = cardList.Last();


            return GetCardDetailsAPI(LastCard.id);
        }

        public void CreateCard(string _title, string _description, int _status)
        {
            using var client = new HttpClient();
            Card newCard = new Card();
            newCard.title = _title;
            newCard.description = _description;
            newCard.status = _status;

            var endpoint = new Uri("http://79.172.201.168/Cards/Add");
            var newCardRequest = JsonConvert.SerializeObject(newCard);
            var payLoad = new StringContent(content: newCardRequest, encoding: Encoding.UTF8, mediaType: "application/json");
            var result = client.PostAsync(endpoint, payLoad).Result;
            var resultText = result.Content.ReadAsStringAsync().Result;
            var resultCode = result.IsSuccessStatusCode;

            var responseText = resultCode ? "1" : resultText;

            GetAllCardsOfUser();
        }


        public string UpdateCardAPI(string _id, string _title, string _description, int _status, int _position, string _asigneeId)
        {
            using var client = new HttpClient();

            string currentUserToken = MyAppContext.getUserData().token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);

            CarUpdateRequestBody newCard = new CarUpdateRequestBody();
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

            var allCards = GetAllCardsOfUserAPI();
            List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(allCards);
            Card LastCard = cardList.Find(x => x.id == _id);
            return JsonConvert.SerializeObject(LastCard);
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

     
        public string DeleteCardAPI(string _id)
        {
            using var client = new HttpClient();

            string currentUserToken = MyAppContext.getUserData().token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentUserToken);

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
            return result.Content.ReadAsStringAsync().Result;
        }
        public void DeleteCard(string _id)
        {
            var result = DeleteCardAPI(_id);
            var responseText = result;

            GetAllCardsOfUser();
        }

    }
}
