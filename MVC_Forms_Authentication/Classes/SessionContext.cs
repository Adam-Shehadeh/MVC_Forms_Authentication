using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using MVC_Forms_Authentication.Models;

namespace MVC_Forms_Authentication.Classes {
    public static class SessionContext {
        public static void SetAuthenticationToken(bool isPersistant, User userData) {
            string data = null;
            if (userData != null)
                data = new JavaScriptSerializer().Serialize(userData);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userData.Name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, userData.UserID.ToString());
            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData) {
                HttpOnly = true,
                Expires = ticket.Expiration
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}