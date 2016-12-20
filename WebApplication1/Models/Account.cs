using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public string Mail { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}