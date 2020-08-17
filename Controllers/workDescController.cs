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

        [HttpPost]
        public ActionResult AddWorkDesc(vm_workDesc workDescAdd)
        {

            //db.Database.ExecuteSqlCommand("Insert into tbl_dailyReport Values({0},{1},{2},{3},{4},{5},{6})",
            //   dailyReportAdd.jobID, dailyReportAdd.date, dailyReportAdd.subJobID, dailyReportAdd.startTime, dailyReportAdd.endTime, dailyReportAdd.lunchHours, dailyReportAdd.equipment);

            //--IF THE DAILY REPORT DOESN'T ALREADY EXIST...
            db.Database.ExecuteSqlCommand("IF NOT EXISTS(SELECT * FROM tbl_dailyReportTimeEntry WHERE dailyReportID = {0})" +
            "BEGIN" +

            "DECLARE @id INT" +
            "INSERT INTO tbl_dailyReportTimeEntry VALUES({0}, {1})" +
            "SET @id = SCOPE_IDENTITY()" +
            "INSERT INTO tbl_dailyReportTimeEntryUsers(timeEntryID, userName) VALUES(@id, {2})" +

            "END" +

            //--IF THE DAILY REPORT DOES ALREADY EXIST...
            "ELSE" +
            "BEGIN" +

            "SET @timeEntryID =" +
                "(SELECT tbl_dailyReportTimeEntry.timeEntryID" +
                "FROM tbl_dailyReportTimeEntry" +
                "WHERE" +

                "tbl_dailyReportTimeEntry.dailyReportID like {0})" +

                "INSERT INTO tbl_dailyReportTimeEntryUsers(timeEntryID, userName) VALUES(@timeEntryID, {2})" +

            "END)", workDescAdd.dailyReportID, workDescAdd.workDescription, workDescAdd.userName);

            //db.Database.ExecuteSqlCommand("Insert into tbl_dailyReport Values({0},{1},{2},{3},{4},{5},{6})",
            //    dailyReportAdd.jobID, dailyReportAdd.date, dailyReportAdd.subJobID, dailyReportAdd.startTime, dailyReportAdd.endTime, dailyReportAdd.lunchHours, dailyReportAdd.equipment);

            return new EmptyResult();
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
