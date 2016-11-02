using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteka.Models;

namespace Biblioteka.Controllers
{
    public class AdminPanelController : Controller
    {
        //
        // GET: /AdminPanel/
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(/*[Bind(Include = "CityID,Name,CountryID")]*/ Book book)
        {
            if (!ModelState.IsValid)
                ModelState.Clear();
            book.State = "1";
            using (DatabaseEntities dE = new DatabaseEntities())
            {
                dE.BookSet.Add(book);
                dE.SaveChanges();
            }
            return RedirectToAction("Main");
        }

        public ActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTag(Tag tag)
        {
            if (!ModelState.IsValid)
                return View();
            using (DatabaseEntities dE = new DatabaseEntities())
            {
                dE.TagSet.Add(tag);
                dE.SaveChanges();
                return RedirectToAction("Main");
            }
        }

    }

}
