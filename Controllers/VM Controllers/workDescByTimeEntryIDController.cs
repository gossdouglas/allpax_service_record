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
using System.Data.SqlClient;
using System.Configuration;
using System.Dynamic;

namespace allpax_service_record.Controllers
{
    public class workDescByTimeEntryID : Controller
    {
        private allpaxServiceRecordEntities db = new allpaxServiceRecordEntities();

        // GET: customers
        //public ActionResult Index(int dailyReportID)
            public ActionResult Index()
        {
            var sql = db.tbl_dailyReportTimeEntry.SqlQuery("SELECT * from tbl_dailyReportTimeEntry").ToList();

            return View(sql.ToList());
        }

        [HttpPost]
        public ActionResult AddWorkDesc(vm_workDesc workDescAdd)
        {
             db.Database.ExecuteSqlCommand("Insert into tbl_dailyReportTimeEntry Values({0},{1})",
                workDescAdd.dailyReportID, workDescAdd.workDescription); 
            return new EmptyResult();
            //return RedirectToAction("Home", "Index");
            //return Redirect("/Home");
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
