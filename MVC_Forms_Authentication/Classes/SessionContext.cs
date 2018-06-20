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
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userData.Name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, new JavaScriptSerializer().Serialize(userData));
            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData) {
                HttpOnly = true,
                Expires = ticket.Expiration
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static User GetUser() {
            try {
                HttpCookie chocolate_fucking_chip_cookie = HttpContext.Current.Request.Cookies["LoginData"];
                if (chocolate_fucking_chip_cookie != null) {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(chocolate_fucking_chip_cookie.Value);
                    User local = new JavaScriptSerializer().Deserialize<User>(ticket.UserData);
                    return local;
                } else
                    return null;
            } catch {
                return null;
            }

        }
    }
}