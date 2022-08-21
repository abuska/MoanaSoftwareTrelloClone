using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

using TrelloClone.Controllers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrelloClone.API
{
    [Route("api/Card")]
    [ApiController]
    public class CardAPIController : ControllerBase
    {
        // GET: api/<CardAPIController>
        [HttpGet]
        public string Get()
        {

            CardController CC = new CardController();
            return CC.GetAllCardsOfUserAPI();
        }

        // GET api/<CardAPIController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            CardController CC = new CardController();
            return CC.GetCardDetailsAPI(id); 
        }

        // POST api/<CardAPIController>
        [HttpPost]
        public OkObjectResult Post([FromBody] Models.CardCreateRequestBody card)
        {
            CardController CC = new CardController();
            return Ok(CC.CreateCardAPI(card.title, card.description, card.status));
        }

        // PUT api/<CardAPIController>/5
        [HttpPut("{id}")]
        public string Put([FromBody] Models.CarUpdateRequestBody card)
        {
            CardController CC = new CardController();
            return CC.UpdateCardAPI(card.id, card.title, card.description, card.status, card.position, card.asigneeId);
        }

        // DELETE api/<CardAPIController>/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            CardController CC = new CardController();
            return CC.DeleteCardAPI(id);
        }
    }
}
