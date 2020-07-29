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
    public class jobsController : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: jobs
        public ActionResult Index()
        {
            var tbl_Jobs = db.tbl_Jobs.Include(t => t.tbl_customers);
            return View(tbl_Jobs.ToList());
        }

        // GET: jobs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Jobs tbl_Jobs = db.tbl_Jobs.Find(id);
            if (tbl_Jobs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Jobs);
        }

        // GET: jobs/Create
        public ActionResult Create()
        {
            ViewBag.customerCode = new SelectList(db.tbl_customers, "customerCode", "customerName");
            return View();
        }

        // POST: jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobID,description,customerCode,customerContact,active")] tbl_Jobs tbl_Jobs)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Jobs.Add(tbl_Jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerCode = new SelectList(db.tbl_customers, "customerCode", "customerName", tbl_Jobs.customerCode);
            return View(tbl_Jobs);
        }

        // GET: jobs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Jobs tbl_Jobs = db.tbl_Jobs.Find(id);
            if (tbl_Jobs == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerCode = new SelectList(db.tbl_customers, "customerCode", "customerName", tbl_Jobs.customerCode);
            return View(tbl_Jobs);
        }

        // POST: jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobID,description,customerCode,customerContact,active")] tbl_Jobs tbl_Jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerCode = new SelectList(db.tbl_customers, "customerCode", "customerName", tbl_Jobs.customerCode);
            return View(tbl_Jobs);
        }

        // GET: jobs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Jobs tbl_Jobs = db.tbl_Jobs.Find(id);
            if (tbl_Jobs == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Jobs);
        }

        // POST: jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Jobs tbl_Jobs = db.tbl_Jobs.Find(id);
            db.tbl_Jobs.Remove(tbl_Jobs);
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
