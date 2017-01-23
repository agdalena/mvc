using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Rent
    {
        public int RentID {get; set;}
        public int AccountID {get; set;}
        public int BookID {get; set;}
        public string RentDate { get; set; }
        public string EndDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Book Book { get; set; }
    }
}