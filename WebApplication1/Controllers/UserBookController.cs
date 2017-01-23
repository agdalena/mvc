using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;
using WebApplication1.Helper;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class UserBookController : Controller
    {
        // GET: UserBook
        private LibraryContext db = new LibraryContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.Where(b => b.State == "Dostępna").ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.BookCategories.Where(cid => cid.BookID == id).FirstOrDefault().Category.Name.ToString();
            var tag = db.BookTags.Where(tid => tid.BookID == id).ToList();
            ViewBag.Category = category;
            ViewBag.Tag = tag;
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            Cart cart = new Cart();

            if (Methods.UserId != null)
            {
                cart.AccountID = Methods.UserId.GetValueOrDefault();
                cart.Author = book.Author;
                cart.ISBN = book.ISBN;
                cart.State = book.State;
                cart.State = "W koszyku";
                book.State = "W koszyku";
                cart.Title = book.Title;
                //db.Entry(book).State = EntityState.Modified;

                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index", "Carts");
            }
            return View();
        }


       
    }
}