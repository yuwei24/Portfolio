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
        [Authorize]
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
                string chartTitle = "Total Assets";
                DateTime cutoff = DateTime.Now.AddDays(-2);

                if (id != 0)
                {
                    chartTitle = db.Funds.Single(a => a.Id == id).FundName;
                    cutoff = DateTime.Now.AddDays(-1);
                }
                
                var result = db.Assets.Where(assets => (id == 0 || assets.FundId == id) && assets.AssetDate <= cutoff)
               .GroupBy(assets => assets.AssetDate)
               .Select(group => new { Date = group.Key, Assets = group.Sum(item => item.Assets) })
               .OrderBy(assets => assets.Date).ToList();

                var result2 = db.usp_SelectAssetsInvestmentOnlyAll().Where(assets => (id == 0 || assets.FundId == id) && assets.AssetDate <= cutoff)
                .GroupBy(assets => assets.AssetDate)
                .Select(group => new { Date = group.Key, Assets = group.Sum(item => item.Assets) })
                .OrderBy(assets => assets.Date).ToList(); 

                double minValue = (double)result.Min(assets => assets.Assets) - 500;

                var key = new Chart(width: 850, height: 400)
                    .AddSeries(name:"Portfolio", chartType:"Line",
                        xValue: result, xField: "Date",
                        yValues: result, yFields: "Assets")
                    .AddSeries(name: "Investment", chartType: "Line",
                        xValue: result2, xField: "Date",
                        yValues: result2, yFields: "Assets")

                    .SetYAxis(min: minValue)
                    .AddTitle(text: chartTitle)
                        
                    .Write("png");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public ActionResult GetInvestmentChart()
        {
            try
            {
                string chartTitle = "Total Investment";

                var result = db.usp_SelectInvestmentAll().ToList();

                var key = new Chart(width: 490, height: 350)
                    .AddSeries(name: "Investment", chartType: "Column",
                        xValue: result, xField: "Month",
                        yValues: result, yFields: "Amount")
                    .AddTitle(text: chartTitle)
                    .Write("png");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public ActionResult GetPortfolioChart()
        {
            try
            {
                string chartTitle = "Growth/Total: ";
                DateTime cutoff = db.Assets.Max(asset => asset.AssetDate);
                cutoff = db.Assets.Where(asset => asset.AssetDate < cutoff).Max(asset => asset.AssetDate);

                var result = db.Assets.Include("Fund").Where(assets => assets.AssetDate == cutoff.Date)
               .GroupBy(assets => assets.Fund.Category)
               .Select(group => new { Category = group.Key, Assets = group.Sum(item => item.Assets) })
               .ToList();

                decimal growth = result[0].Assets / result.Sum(asset => asset.Assets);
                decimal match = result[1].Assets / result.Sum(asset => asset.Assets);

                chartTitle += string.Format("{0:P}", growth);
                var key = new Chart(width: 350, height: 350)
                    .AddSeries(name: "Portfolio", chartType: "Pie",
                    xValue: result, xField: "Category", 
                    yValues: result, yFields: "Assets")                    
                    .AddTitle(text: chartTitle)
                    .Write("png");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public ContentResult GetLastUpdatedTimestamp()
        {
            DateTime cutoff = db.JobEventLogs.Where(job => job.Job == "AssetLoad").Max(job => job.LastRunOn);
            return Content(cutoff.ToString("dd/MM/yy hh:mm"));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}