using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteka.Models;
using Biblioteka.Helper;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account account)
        {
            using (DatabaseEntities dE = new DatabaseEntities())
            {
                var user = dE.AccountSet.Single(u => u.Login == account.Login && u.Password == account.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", Consts.LOGIN_ERROR);
                    return View();
                }
                Session[Consts.SESSION_ID] = user.IdAcount.ToString();
                Session[Consts.SESSION_LOGIN] = user.Login.ToString();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account acc)
        {
            if (!ModelState.IsValid)
                ModelState.Clear();
            acc.Permission = "User";
            using (DatabaseEntities dE = new DatabaseEntities())
            {
               
                dE.AccountSet.Add(acc);
                dE.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }


    }
}