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
        [Authorize]
        public ViewResult Index()
        {
            return View(db.Deposits.Include("Fund").OrderBy(d => d.MatureDate).ToList());
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
            ViewBag.Bank = new SelectList(new[] { "工商银行", "杭州银行", "杭银国债" });
            ViewBag.FundId = new SelectList(db.Funds.Where<Fund>(f => f.FundType == "CASH") , "Id", "FundName"); ;

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

                #region commented code
                /*
                bool hasAssets = false;
                foreach (Asset asset in db.Assets.Include("Fund").Where(asset => asset.FundId == deposit.FundId && asset.AssetDate >= deposit.DepositDate))
                {
                    asset.Shares += deposit.Amount;
                    asset.Assets += 0;
                    hasAssets = true;
                }

                if (!hasAssets)
                {
                    Asset asset = Asset.CreateAsset(0, deposit.FundId.Value, deposit.DepositDate, deposit.Amount, 0);
                    db.Assets.AddObject(asset);
                }
                */
                #endregion

                Trade trade = Trade.CreateTrade(0, deposit.FundId.Value, deposit.DepositDate, deposit.Amount, deposit.Amount);
                db.Trades.AddObject(trade);

                Reminder reminder = Reminder.CreateReminder(0, deposit.MatureDate);
                reminder.Remarks = deposit.Fund.FundName + "到期";
                db.Reminders.AddObject(reminder);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(deposit);
        }

        //
        // GET: /Deposit/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Bank = new SelectList(new[] { "工商银行", "杭州银行", "杭银国债" });
            ViewBag.FundId = new SelectList(db.Funds.Where<Fund>(f => f.FundType == "CASH"), "Id", "FundName"); ;
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

            Trade trade = Trade.CreateTrade(0, deposit.FundId.Value, deposit.MatureDate, 0 - deposit.Amount, 0 - deposit.Amount);
            db.Trades.AddObject(trade);

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