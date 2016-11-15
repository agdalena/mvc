using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string State { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}