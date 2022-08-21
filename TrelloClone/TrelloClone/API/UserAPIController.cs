using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TrelloClone.Controllers;
using TrelloClone.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrelloClone.API
{
    [ApiController]
    public class UserApiController : ControllerBase
    {

        [Route("api/User")]
        // GET: api/<UserApiController>
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(MyAppContext.getUserData());
        }

        // GET api/<UserApiController>/5
        [HttpGet("api/User/all")]
        public string GetAll()
        {
            UserAuthController UAC = new UserAuthController();
            return JsonConvert.SerializeObject(UAC.GetAllUsersAPI());
        }

    }
}
