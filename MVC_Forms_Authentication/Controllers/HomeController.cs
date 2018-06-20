using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Forms_Authentication.Models;
using MVC_Forms_Authentication.Classes;
using System.Web.Security;

namespace MVC_Forms_Authentication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.User = SessionContext.GetUser() ?? null;
            return View();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password) {
            try {
                var tempUser = new User();
                tempUser.Username = username;
                tempUser.Password = password;
                var authenticatedUser = UserRepository.GetByUsernameAndPassword(tempUser);
                if (authenticatedUser != null) {
                    SessionContext.SetAuthenticationToken(false, authenticatedUser);
                    return RedirectToAction("Index", "Home");
                } else {
                    return RedirectToAction("Login", "Home");
                }
            } catch {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}