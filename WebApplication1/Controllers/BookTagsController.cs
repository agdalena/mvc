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

namespace WebApplication1.Controllers
{
    public class BookTagsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: BookTags
        public ActionResult Index()
        {
            var bookTags = db.BookTags.Include(b => b.Book).Include(b => b.Tag);
            return View(bookTags.ToList());
        }

        // GET: BookTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTag bookTag = db.BookTags.Find(id);
            if (bookTag == null)
            {
                return HttpNotFound();
            }
            return View(bookTag);
        }

        // GET: BookTags/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title");
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "Name");
            return View();
        }

        // POST: BookTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookTagID,BookID,TagID")] BookTag bookTag)
        {
            if (ModelState.IsValid)
            {
                db.BookTags.Add(bookTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", bookTag.BookID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "Name", bookTag.TagID);
            return View(bookTag);
        }

        // GET: BookTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTag bookTag = db.BookTags.Find(id);
            if (bookTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", bookTag.BookID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "Name", bookTag.TagID);
            return View(bookTag);
        }

        // POST: BookTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookTagID,BookID,TagID")] BookTag bookTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", bookTag.BookID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "Name", bookTag.TagID);
            return View(bookTag);
        }

        // GET: BookTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTag bookTag = db.BookTags.Find(id);
            if (bookTag == null)
            {
                return HttpNotFound();
            }
            return View(bookTag);
        }

        // POST: BookTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookTag bookTag = db.BookTags.Find(id);
            db.BookTags.Remove(bookTag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
