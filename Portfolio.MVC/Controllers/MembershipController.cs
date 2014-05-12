using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.MVC.Models;
using System.Web.Security;

namespace Portfolio.MVC.Controllers
{
    public class MembershipController : Controller
    {
        //
        // GET: /Membership/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MembershipModel model)
        {
            bool authenticated = FormsAuthentication.Authenticate(model.UserName, model.PassWord);
            if (authenticated)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), true, String.Empty, FormsAuthentication.FormsCookiePath);
                string encryptedCookie = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);
                cookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(cookie);                
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
