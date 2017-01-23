using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Helper
{
    public static class Methods
    {
        public static int? UserId { get; set; }
        public static string UserMail { get; set; }
        public static string Permission { get; set; }
        public static bool IsActive { get; set; }

        public static void SaveUserSession(int? id, string mail, string permission, bool isActive)
        {
            UserId = id;
            UserMail = mail;
            Permission = permission;
            IsActive = isActive;
        }

        public static bool CheckUserPermission()
        {
            if (Permission != "User")
                return false;
            return true;
        }

        public static bool CheckWorkerPermission()
        {
            if (Permission != "Worker")
                return false;
            return true;
        }

        public static bool CheckAdminPermission()
        {
            if (Permission != "Admin")
                return false;
            return true;
        }

        public static bool CheckIsActive()
        {
            if (IsActive==false)
                return false;
            return true;
        }

        public static Book SearchBook(LibraryContext db, Search toSearch)
        {
            Book book = new Book();
            var checkThis = db.Books.Single(u => u.Author == toSearch.Text || u.Title == toSearch.Text || u.ISBN == toSearch.Text);

            if (checkThis.Title == toSearch.Text || checkThis.Author == toSearch.Text || checkThis.ISBN.ToString() == toSearch.Text)
                book = db.Books.Find(checkThis.BookID);
            return book;
        }

        public static string RegisterSuccess { get; set; }  //powodzenie rejestracji
        public static string LoginFailed { get; set; }   //nie ma takiego konta
        public static string AccountActive { get; set; }   //konto zajete
    }
}