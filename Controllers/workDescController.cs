using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using allpax_service_record.Models;
using allpax_service_record.Models.View_Models;

namespace allpax_service_record.Controllers
{
    public class workDescController : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: workDesc
        public ActionResult Index(int dailyReportID)
         {
            //var sql = db.tbl_dailyReportTimeEntry.SqlQuery("SELECT * from tbl_dailyReportTimeEntry").ToList();

            //var sql = db.Database.SqlQuery<vm_workDesc>("SELECT * from tbl_dailyReportTimeEntry").ToList();

            var sql = db.Database.SqlQuery<vm_workDesc>("SELECT * " +
                "FROM tbl_dailyReportTimeEntry " +
                "WHERE " +

                "tbl_dailyReportTimeEntry.dailyReportID = {0}", dailyReportID);

            return View(sql.ToList());
        }

        // GET: workDesc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vm_workDesc vm_workDesc = db.vm_workDesc.Find(id);
            if (vm_workDesc == null)
            {
                return HttpNotFound();
            }
            return View(vm_workDesc);
        }

        // GET: workDesc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: workDesc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "timeEntryID,dailyReportID,workDescription,userName")] vm_workDesc vm_workDesc)
        {
            if (ModelState.IsValid)
            {
                db.vm_workDesc.Add(vm_workDesc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm_workDesc);
        }

        // GET: workDesc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vm_workDesc vm_workDesc = db.vm_workDesc.Find(id);
            if (vm_workDesc == null)
            {
                return HttpNotFound();
            }
            return View(vm_workDesc);
        }

        // POST: workDesc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "timeEntryID,dailyReportID,workDescription,userName")] vm_workDesc vm_workDesc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vm_workDesc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm_workDesc);
        }

        // GET: workDesc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vm_workDesc vm_workDesc = db.vm_workDesc.Find(id);
            if (vm_workDesc == null)
            {
                return HttpNotFound();
            }
            return View(vm_workDesc);
        }

        // POST: workDesc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vm_workDesc vm_workDesc = db.vm_workDesc.Find(id);
            db.vm_workDesc.Remove(vm_workDesc);
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
