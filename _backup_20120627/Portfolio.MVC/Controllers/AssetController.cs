using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.MVC.Models;
using System.Web.Helpers;

namespace Portfolio.MVC.Controllers
{
    public class AssetController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        //
        // GET: /Asset/

        public ViewResult Index()
        {
            var assets = db.Assets.Include("Fund");
            return View(assets.ToList());
        }

        //
        // GET: /Asset/Details/5

        public ViewResult Details(int id)
        {
            Asset asset = db.Assets.Single(a => a.Id == id);
            return View(asset);
        }

        //
        // GET: /Asset/Create

        public ActionResult Create()
        {
            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundCode");
            return View();
        }

        //
        // POST: /Asset/Create

        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.AddObject(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundCode", asset.FundId);
            return View(asset);
        }

        //
        // GET: /Asset/Edit/5

        public ActionResult Edit(int id)
        {
            Asset asset = db.Assets.Single(a => a.Id == id);
            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundCode", asset.FundId);
            return View(asset);
        }

        //
        // POST: /Asset/Edit/5

        [HttpPost]
        public ActionResult Edit(Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Attach(asset);
                db.ObjectStateManager.ChangeObjectState(asset, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FundId = new SelectList(db.Funds, "Id", "FundCode", asset.FundId);
            return View(asset);
        }

        //
        // GET: /Asset/Delete/5

        public ActionResult Delete(int id)
        {
            Asset asset = db.Assets.Single(a => a.Id == id);
            return View(asset);
        }

        //
        // POST: /Asset/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Asset asset = db.Assets.Single(a => a.Id == id);
            db.Assets.DeleteObject(asset);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAssetChart(int id)
        {                                     
            try
            {
                DateTime cutoff = DateTime.Now.AddDays(-2);
                var result = db.Assets.Where(assets => (id == 0 || assets.FundId == id) && assets.AssetDate <= cutoff)
               .GroupBy(assets => assets.AssetDate)
               .Select(group => new { Date = group.Key, Assets = group.Sum(item => item.Assets) })
               .OrderBy(assets => assets.Date).ToList();

                double minValue = (double)result.Min(assets => assets.Assets) - 10000;

                var key = new Chart(width: 500, height: 360)
                    .AddSeries(name:"Portfolio", chartType:"Line",
                        xValue: result, xField: "Date",
                        yValues: result, yFields: "Assets")
                        .SetYAxis(title: "Total Assets",  min: minValue )
                    .Write();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}