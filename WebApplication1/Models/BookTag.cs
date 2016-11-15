
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class BookTag
    {
        public int BookTagID { get; set; }
        public int BookID { get; set; }
        public int TagID { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}