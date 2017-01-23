using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAL;
using WebApplication1.ModelView;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ActionResult Index()
        {
            var bookList = db.Books.Take(4).ToList();
            var messageList = db.Messages.Take(3).ToList();
            HomeModelView hMV = new HomeModelView(bookList, messageList);
            return View(hMV);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}