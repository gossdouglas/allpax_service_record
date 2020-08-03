﻿using System;
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

        // GET: customers
        public ActionResult Index()
        {
            //return View(db.tbl_customers.ToList());
            var sql = db.tbl_dailyReport.SqlQuery("SELECT * from tbl_dailyReport").ToList();

            return View(sql.ToList());
        }

        //begin CMPS 411 controller code
        [HttpPost]
        public ActionResult AddDailyReport(tbl_dailyReport dailyReportAdd)
        {
            //db.Database.ExecuteSqlCommand("Insert into cmps411.tbl_customer Values({0},{1},{2}, {3}, {4}, {5})",
            //    customerAdd.customerCode, customerAdd.name, customerAdd.address, customerAdd.city, customerAdd.state, customerAdd.zipCode);

            //db.Database.ExecuteSqlCommand("Insert into tbl_customers Values({0}, {1}, {2}, {3})",
            //    customerAdd.jobID, customerAdd.date, customerAdd.startTime, customerAdd.endTime);

             db.Database.ExecuteSqlCommand("Insert into tbl_dailyReport Values({0},{1},{2},{3},{4},{5},{6})",
                dailyReportAdd.jobID, dailyReportAdd.date, dailyReportAdd.subJobID, dailyReportAdd.startTime, dailyReportAdd.endTime, dailyReportAdd.lunchHours, dailyReportAdd.equipment); 
            return new EmptyResult();
        }

        public ActionResult DeleteCustomer(tbl_dailyReport custDelete)
        {
            //db.Database.ExecuteSqlCommand("DELETE FROM tbl_customers WHERE id=({0})", custDelete.id);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(tbl_dailyReport custUpdate)
        {
            //db.Database.ExecuteSqlCommand("UPDATE cmps411.tbl_customer SET customerCode={0},name={1},address={2}, city={3}, state={4}, zipCode={5} WHERE id={6}",
            //      custUpdate.customerCode, custUpdate.name, custUpdate.address, custUpdate.city, custUpdate.state, custUpdate.zipCode, custUpdate.id);

            //db.Database.ExecuteSqlCommand("UPDATE tbl_customers SET customerCode={0}, customerName={1}, address={2} WHERE id={3}",
            //      custUpdate.customerCode, custUpdate.customerName, custUpdate.address, custUpdate.id);

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
