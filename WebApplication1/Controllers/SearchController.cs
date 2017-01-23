using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;
using WebApplication1.Helper;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Search toSearch)
        {
            Book book = Methods.SearchBook(db, toSearch);
            return RedirectToAction("Details", "UserBook", new { id = book.BookID });
        }

        public ActionResult IndexWorker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexWorker(Search toSearch)
        {
            Book book = Methods.SearchBook(db, toSearch);
            return RedirectToAction("Details", "Books", new { id = book.BookID });
        }
    }
}
