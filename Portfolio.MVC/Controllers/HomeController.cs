using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.MVC.Models;

namespace Portfolio.MVC.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            DateTime cutoff = DateTime.Now.AddDays(-2);
            var funds = db.Funds.Where(f => f.Active == true && f.Assets.Count() > 0).ToList();
            return View(funds);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
