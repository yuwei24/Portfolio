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
    public class DepositController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        //
        // GET: /Deposit/

        public ViewResult Index()
        {
            return View(db.Deposits.ToList());
        }

        //
        // GET: /Deposit/Details/5

        public ViewResult Details(int id)
        {
            Deposit deposit = db.Deposits.Single(d => d.Id == id);
            return View(deposit);
        }

        //
        // GET: /Deposit/Create

        public ActionResult Create()
        {
            ViewBag.Bank = new SelectList(new[]{"工商银行", "杭州银行"});

            return View();
        }

        //
        // POST: /Deposit/Create

        [HttpPost]
        public ActionResult Create(Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                db.Deposits.AddObject(deposit);

                foreach (Asset asset in db.Assets.Include("Fund").Where(asset => asset.Fund.FundCode == "FIXDEP" && asset.AssetDate >= deposit.DepositDate))
                {
                    asset.Shares += deposit.Amount;
                    asset.Assets += deposit.Amount;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deposit);
        }

        //
        // GET: /Deposit/Edit/5

        public ActionResult Edit(int id)
        {
            Deposit deposit = db.Deposits.Single(d => d.Id == id);
            return View(deposit);
        }

        //
        // POST: /Deposit/Edit/5

        [HttpPost]
        public ActionResult Edit(Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                db.Deposits.Attach(deposit);
                db.ObjectStateManager.ChangeObjectState(deposit, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deposit);
        }

        //
        // GET: /Deposit/Delete/5

        public ActionResult Delete(int id)
        {
            Deposit deposit = db.Deposits.Single(d => d.Id == id);
            return View(deposit);
        }

        //
        // POST: /Deposit/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Deposit deposit = db.Deposits.Single(d => d.Id == id);
            db.Deposits.DeleteObject(deposit);
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