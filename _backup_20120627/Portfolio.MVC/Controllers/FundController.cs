using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.MVC.Models;

namespace Portfolio.MVC.Controllers
{ 
    public class FundController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        //
        // GET: /Fund/

        public ViewResult Index()
        {
            return View(db.Funds.ToList());
        }

        //
        // GET: /Fund/Details/5

        public ViewResult Details(int id)
        {
            Fund fund = db.Funds.Single(f => f.Id == id);
            return View(fund);
        }

        //
        // GET: /Fund/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Fund/Create

        [HttpPost]
        public ActionResult Create(Fund fund)
        {
            if (ModelState.IsValid)
            {
                db.Funds.AddObject(fund);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fund);
        }
        
        //
        // GET: /Fund/Edit/5
 
        public ActionResult Edit(int id)
        {
            Fund fund = db.Funds.Single(f => f.Id == id);
            return View(fund);
        }

        //
        // POST: /Fund/Edit/5

        [HttpPost]
        public ActionResult Edit(Fund fund)
        {
            if (ModelState.IsValid)
            {
                db.Funds.Attach(fund);
                db.ObjectStateManager.ChangeObjectState(fund, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fund);
        }

        //
        // GET: /Fund/Delete/5
 
        public ActionResult Delete(int id)
        {
            Fund fund = db.Funds.Single(f => f.Id == id);
            return View(fund);
        }

        //
        // POST: /Fund/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Fund fund = db.Funds.Single(f => f.Id == id);
            db.Funds.DeleteObject(fund);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}