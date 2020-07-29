using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using allpax_service_record.Models;

namespace allpax_service_record.Controllers
{
    public class dailyReportController : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: dailyReport
        public ActionResult Index()
        {
            var tbl_dailyReport = db.tbl_dailyReport.Include(t => t.tbl_Jobs);
            return View(tbl_dailyReport.ToList());
        }

        // GET: dailyReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dailyReport tbl_dailyReport = db.tbl_dailyReport.Find(id);
            if (tbl_dailyReport == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dailyReport);
        }

        // GET: dailyReport/Create
        public ActionResult Create()
        {
            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description");
            return View();
        }

        // POST: dailyReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dailyReportID,date,jobID,subJobID,start,C_end,lunchHours")] tbl_dailyReport tbl_dailyReport)
        {
            if (ModelState.IsValid)
            {
                db.tbl_dailyReport.Add(tbl_dailyReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description", tbl_dailyReport.jobID);
            return View(tbl_dailyReport);
        }

        // GET: dailyReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dailyReport tbl_dailyReport = db.tbl_dailyReport.Find(id);
            if (tbl_dailyReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description", tbl_dailyReport.jobID);
            return View(tbl_dailyReport);
        }

        // POST: dailyReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dailyReportID,date,jobID,subJobID,start,C_end,lunchHours")] tbl_dailyReport tbl_dailyReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_dailyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description", tbl_dailyReport.jobID);
            return View(tbl_dailyReport);
        }

        // GET: dailyReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dailyReport tbl_dailyReport = db.tbl_dailyReport.Find(id);
            if (tbl_dailyReport == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dailyReport);
        }

        // POST: dailyReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_dailyReport tbl_dailyReport = db.tbl_dailyReport.Find(id);
            db.tbl_dailyReport.Remove(tbl_dailyReport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
