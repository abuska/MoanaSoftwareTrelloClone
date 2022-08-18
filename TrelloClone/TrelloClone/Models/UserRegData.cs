using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrelloClone.Models
{
    public class UserRegData
    {
        public string email { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
    }
}