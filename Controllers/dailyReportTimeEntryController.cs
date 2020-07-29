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
    public class dailyReportTimeEntryController : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: dailyReportTimeEntry
        public ActionResult Index()
        {
            var tbl_dailyReportTimeEntry = db.tbl_dailyReportTimeEntry.Include(t => t.tbl_dailyReport);
            return View(tbl_dailyReportTimeEntry.ToList());
        }

        // GET: dailyReportTimeEntry/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry = db.tbl_dailyReportTimeEntry.Find(id);
            if (tbl_dailyReportTimeEntry == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dailyReportTimeEntry);
        }

        // GET: dailyReportTimeEntry/Create
        public ActionResult Create()
        {
            ViewBag.dailyReportID = new SelectList(db.tbl_dailyReport, "dailyReportID", "jobID");
            return View();
        }

        // POST: dailyReportTimeEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "timeEntryID,dailyReportID,workDescription")] tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry)
        {
            if (ModelState.IsValid)
            {
                db.tbl_dailyReportTimeEntry.Add(tbl_dailyReportTimeEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dailyReportID = new SelectList(db.tbl_dailyReport, "dailyReportID", "jobID", tbl_dailyReportTimeEntry.dailyReportID);
            return View(tbl_dailyReportTimeEntry);
        }

        // GET: dailyReportTimeEntry/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry = db.tbl_dailyReportTimeEntry.Find(id);
            if (tbl_dailyReportTimeEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.dailyReportID = new SelectList(db.tbl_dailyReport, "dailyReportID", "jobID", tbl_dailyReportTimeEntry.dailyReportID);
            return View(tbl_dailyReportTimeEntry);
        }

        // POST: dailyReportTimeEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "timeEntryID,dailyReportID,workDescription")] tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_dailyReportTimeEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dailyReportID = new SelectList(db.tbl_dailyReport, "dailyReportID", "jobID", tbl_dailyReportTimeEntry.dailyReportID);
            return View(tbl_dailyReportTimeEntry);
        }

        // GET: dailyReportTimeEntry/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry = db.tbl_dailyReportTimeEntry.Find(id);
            if (tbl_dailyReportTimeEntry == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dailyReportTimeEntry);
        }

        // POST: dailyReportTimeEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry = db.tbl_dailyReportTimeEntry.Find(id);
            db.tbl_dailyReportTimeEntry.Remove(tbl_dailyReportTimeEntry);
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
