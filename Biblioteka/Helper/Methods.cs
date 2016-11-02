using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Helper
{
    public class Methods
    {
        public static bool CheckIfUserIsAdmin()
        {
            if (HttpContext.Current.Session[Consts.SESSION_LOGIN] == null)
                return false;
            return true;
        }
    }
}