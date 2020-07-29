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
    public class jobResourceTypesController : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: jobResourceTypes
        public ActionResult Index()
        {
            var tbl_jobResourceTypes = db.tbl_jobResourceTypes.Include(t => t.tbl_Jobs).Include(t => t.tbl_resourceTypes);
            return View(tbl_jobResourceTypes.ToList());
        }

        // GET: jobResourceTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_jobResourceTypes tbl_jobResourceTypes = db.tbl_jobResourceTypes.Find(id);
            if (tbl_jobResourceTypes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_jobResourceTypes);
        }

        // GET: jobResourceTypes/Create
        public ActionResult Create()
        {
            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description");
            ViewBag.resourceTypeID = new SelectList(db.tbl_resourceTypes, "resourceTypeID", "resourceType");
            return View();
        }

        // POST: jobResourceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobID,resourceTypeID,rate")] tbl_jobResourceTypes tbl_jobResourceTypes)
        {
            if (ModelState.IsValid)
            {
                db.tbl_jobResourceTypes.Add(tbl_jobResourceTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description", tbl_jobResourceTypes.jobID);
            ViewBag.resourceTypeID = new SelectList(db.tbl_resourceTypes, "resourceTypeID", "resourceType", tbl_jobResourceTypes.resourceTypeID);
            return View(tbl_jobResourceTypes);
        }

        // GET: jobResourceTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_jobResourceTypes tbl_jobResourceTypes = db.tbl_jobResourceTypes.Find(id);
            if (tbl_jobResourceTypes == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description", tbl_jobResourceTypes.jobID);
            ViewBag.resourceTypeID = new SelectList(db.tbl_resourceTypes, "resourceTypeID", "resourceType", tbl_jobResourceTypes.resourceTypeID);
            return View(tbl_jobResourceTypes);
        }

        // POST: jobResourceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobID,resourceTypeID,rate")] tbl_jobResourceTypes tbl_jobResourceTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_jobResourceTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobID = new SelectList(db.tbl_Jobs, "jobID", "description", tbl_jobResourceTypes.jobID);
            ViewBag.resourceTypeID = new SelectList(db.tbl_resourceTypes, "resourceTypeID", "resourceType", tbl_jobResourceTypes.resourceTypeID);
            return View(tbl_jobResourceTypes);
        }

        // GET: jobResourceTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_jobResourceTypes tbl_jobResourceTypes = db.tbl_jobResourceTypes.Find(id);
            if (tbl_jobResourceTypes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_jobResourceTypes);
        }

        // POST: jobResourceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_jobResourceTypes tbl_jobResourceTypes = db.tbl_jobResourceTypes.Find(id);
            db.tbl_jobResourceTypes.Remove(tbl_jobResourceTypes);
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
