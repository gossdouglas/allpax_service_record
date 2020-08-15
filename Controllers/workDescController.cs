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

                //"tbl_dailyReportTimeEntry.dailyReportID = '51'");
                "tbl_dailyReportTimeEntry.dailyReportID = {0}", dailyReportID);

            //db.Database.ExecuteSqlCommand("DELETE FROM tbl_customers WHERE id=({0})", custDelete.id);

            //db.Database.SqlQuery<vm_dailyReportViewAll>("SELECT tbl_dailyReport.dailyReportID, tbl_Jobs.active, tbl_dailyReport.date, tbl_dailyReport.jobID, " +
            //   "tbl_subJobTypes.description, tbl_customers.customerName, tbl_customers.address FROM tbl_dailyReport " +

            //       "INNER JOIN " +
            //       "tbl_Jobs ON tbl_Jobs.jobID = tbl_dailyReport.jobID " +
            //       "INNER JOIN " +
            //       "tbl_customers ON tbl_customers.customerCode = tbl_Jobs.customerCode " +
            //       "INNER JOIN " +
            //       "tbl_jobSubJobs ON tbl_jobSubJobs.jobID = tbl_Jobs.jobID " +
            //       "INNER JOIN " +
            //       "tbl_subJobTypes ON tbl_subJobTypes.subJobID = tbl_jobSubJobs.subJobID " +
            //       "WHERE " +
            //       "tbl_dailyReport.subJobID = tbl_subJobTypes.subJobID").ToList();


            return View(sql.ToList());

            //return View(db.vm_workDesc.ToList());
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
