using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookCategory
    {
        public int BookCategoryID { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }

    }
}