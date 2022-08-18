using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrelloClone.Models
{
    public class Card
    {
        public string id { get; set; };
        public string title { get; set; };
        public string description { get; set; };
        public int status { get; set; };
        public int position { get; set; };
    }
}