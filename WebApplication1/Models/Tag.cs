using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookTag> BookTags { get; set; }
    }
}