using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
    }
}