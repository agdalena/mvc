using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ModelView
{
    public class HomeModelView
    {
        public static List<Book> BookList;
        public static List<Message> MessageList;
        public HomeModelView(List<Book> _book, List<Message> _message)
        {
            BookList = _book;
            MessageList = _message;
        }
    }
}