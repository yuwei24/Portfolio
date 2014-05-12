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
    public class TradeController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        //
        // GET: /Trade/

        public ViewResult Index()
        {
            var trades = db.Trades.Include("Fund");
            return View(trades.ToList());
        }

        //
        // GET: /Trade/Details/5

        public ViewResult Details(int id)
        {
            Trade trade = db.Trades.Single(t => t.Id == id);
            return View(trade);
        }

        //
        // GET: /Trade/Create

        public ActionResult Create()
        {
            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundName");
            return View();
        } 

        //
        // POST: /Trade/Create

        [HttpPost]
        public ActionResult Create(Trade trade)
        {
            if (ModelState.IsValid)
            {
                db.Trades.AddObject(trade);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundName", trade.FundId);
            return View(trade);
        }
        
        //
        // GET: /Trade/Edit/5
 
        public ActionResult Edit(int id)
        {
            Trade trade = db.Trades.Single(t => t.Id == id);
            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundName", trade.FundId);
            return View(trade);
        }

        //
        // POST: /Trade/Edit/5

        [HttpPost]
        public ActionResult Edit(Trade trade)
        {
            if (ModelState.IsValid)
            {
                db.Trades.Attach(trade);
                db.ObjectStateManager.ChangeObjectState(trade, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundName", trade.FundId);
            return View(trade);
        }

        //
        // GET: /Trade/Delete/5
 
        public ActionResult Delete(int id)
        {
            Trade trade = db.Trades.Single(t => t.Id == id);
            return View(trade);
        }

        //
        // POST: /Trade/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Trade trade = db.Trades.Single(t => t.Id == id);
            db.Trades.DeleteObject(trade);
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