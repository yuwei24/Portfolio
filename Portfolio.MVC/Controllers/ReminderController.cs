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
    public class ReminderController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        //
        // GET: /Reminder/

        public ViewResult Index()
        {
            return View(db.Reminders.Where(r => r.Due > DateTime.Now).OrderBy (r => r.Due).ToList());
        }

        //
        // GET: /Reminder/Details/5

        public ViewResult Details(int id)
        {
            Reminder reminder = db.Reminders.Single(r => r.Id == id);
            return View(reminder);
        }

        //
        // GET: /Reminder/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Reminder/Create

        [HttpPost]
        public ActionResult Create(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                db.Reminders.AddObject(reminder);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(reminder);
        }
        
        //
        // GET: /Reminder/Edit/5
 
        public ActionResult Edit(int id)
        {
            Reminder reminder = db.Reminders.Single(r => r.Id == id);
            return View(reminder);
        }

        //
        // POST: /Reminder/Edit/5

        [HttpPost]
        public ActionResult Edit(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                db.Reminders.Attach(reminder);
                db.ObjectStateManager.ChangeObjectState(reminder, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reminder);
        }

        //
        // GET: /Reminder/Delete/5
 
        public ActionResult Delete(int id)
        {
            Reminder reminder = db.Reminders.Single(r => r.Id == id);
            return View(reminder);
        }

        //
        // POST: /Reminder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Reminder reminder = db.Reminders.Single(r => r.Id == id);
            db.Reminders.DeleteObject(reminder);
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