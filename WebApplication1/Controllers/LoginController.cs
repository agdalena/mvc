using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            Methods.RegisterSuccess = null;
            using (db)
            {
                try
                {
                    var checkData = db.Accounts.Single(u => u.Login == account.Login && u.Password == account.Password);
                    Methods.SaveUserSession(checkData.AccountID, checkData.Mail, checkData.Permission, checkData.IsActive);
                    Methods.LoginFailed = null;
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    Methods.LoginFailed = "Error";
                    return View();
                }
            }
        }


        public ActionResult Register()
        {
            //SqlCommand command = new SqlCommand("DROP DATABASE GameContext2");
            //   SqlCommand command = new SqlCommand("DROP DATABASE ItemSet");
            //    command.Connection.Open();
            //     command.ExecuteNonQuery();
            return View();
        }


        [HttpPost]
        public ActionResult Register([Bind(Include = "AccountID,Login,Password,Mail,Question,Answer,Name,Surname")] Account account)
        {

            if (ModelState.IsValid)
            {
                using (db)
                {
                    try
                    {
                        var checkData = db.Accounts.Single(u => u.Login == account.Login);
                        Methods.AccountActive = "Already";
                        return View(account);
                    }
                    catch
                    {
                        account.IsActive = false;
                        account.Permission = "User";
                        db.Accounts.Add(account);
                        db.SaveChanges();
                        Methods.RegisterSuccess = "Success";
                        Methods.AccountActive = null;
                        //zapisuje do methods
                        return RedirectToAction("Login", "Login");
                    }
                }
            }
            return View(account);
        }

        public ActionResult Remind()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Remind([Bind(Include = "Mail")]Account account)
        {
            var checkData = db.Accounts.Single(u => u.Mail == account.Mail);
            if (checkData!=null)
            {
                return RedirectToAction("Question", "Login", new { id = checkData.AccountID });
            }
            return View();
        }

        public ActionResult Question(int? id)
        {
            var checkData = db.Accounts.Single(u => u.AccountID == id);
            return View();
        }

        [HttpPost]
        public ActionResult Question([Bind(Include = "Answer")]Account account, int? id)
        {
            var checkData = db.Accounts.Single(u => u.AccountID == id);
            if (checkData != null)
                if (checkData.Answer == account.Answer)
                {
                    var pass = checkData.Password;
                  
                }
            return View();
        }

        public ActionResult LogOut()
        {
            Methods.SaveUserSession(null, null,null,false);
            return RedirectToAction("Login", "Login");
        }
    }
}




