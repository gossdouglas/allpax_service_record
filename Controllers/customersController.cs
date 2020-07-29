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
    public class customersController : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: customers
        public ActionResult Index()
        {
            return View(db.tbl_customers.ToList());
        }

        // GET: customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customers tbl_customers = db.tbl_customers.Find(id);
            if (tbl_customers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customers);
        }

        // GET: customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerCode,customerName,address")] tbl_customers tbl_customers)
        {
            if (ModelState.IsValid)
            {
                db.tbl_customers.Add(tbl_customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_customers);
        }

        // GET: customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customers tbl_customers = db.tbl_customers.Find(id);
            if (tbl_customers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customers);
        }

        // POST: customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerCode,customerName,address")] tbl_customers tbl_customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_customers);
        }

        // GET: customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_customers tbl_customers = db.tbl_customers.Find(id);
            if (tbl_customers == null)
            {
                return HttpNotFound();
            }
            return View(tbl_customers);
        }

        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_customers tbl_customers = db.tbl_customers.Find(id);
            db.tbl_customers.Remove(tbl_customers);
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
