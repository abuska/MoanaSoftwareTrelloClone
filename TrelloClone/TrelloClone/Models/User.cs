using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrelloClone.Models
{
    public class User
    {
        public string userId { get; set; }
        public string token { get; set; }
        public string expiresAt { get; set; }
    }
}