using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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

            //var sql = db.Database.SqlQuery<vm_workDesc>("SELECT tbl_dailyReportTimeEntry.dailyReportID, tbl_dailyReportTimeEntry.workDescription, " +
            //"tbl_dailyReportTimeEntry.timeEntryID, tbl_dailyReportTimeEntryUsers.userName " +

            //"FROM tbl_dailyReportTimeEntry " +
            //"INNER JOIN tbl_dailyReportTimeEntryUsers ON " +
            //"tbl_dailyReportTimeEntryUsers.timeEntryID = tbl_dailyReportTimeEntry.timeEntryID " +

            //"WHERE " +

            //"tbl_dailyReportTimeEntry.dailyReportID = {0}", dailyReportID);

            //return View(sql.ToList());

            List<vm_workDesc> workDescs = new List<vm_workDesc>();
            string mainconn = ConfigurationManager.ConnectionStrings["allpaxServiceRecordEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            sqlconn.Open();
           
            //begin query
            string sqlquery1 =
                "SELECT tbl_dailyReportTimeEntry.dailyReportID, tbl_dailyReportTimeEntry.workDescription, " +
                "tbl_dailyReportTimeEntry.timeEntryID " +

                "FROM tbl_dailyReportTimeEntry " +
                "WHERE " +
                "tbl_dailyReportTimeEntry.dailyReportID = @dailyReportID";

            SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn);
            sqlcomm1.Parameters.AddWithValue("@dailyReportID", dailyReportID);
            SqlDataAdapter sda1 = new SqlDataAdapter(sqlcomm1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                vm_workDesc workDesc = new vm_workDesc();

                workDesc.dailyReportID = (int) dr1[0];
                workDesc.workDescription = dr1[1].ToString();
                workDesc.timeEntryID = (int) dr1[2];

                workDesc.userNames = workDescUsersByTimeEntryID(workDesc.timeEntryID);

                workDescs.Add(workDesc);
            }

            //end query for kits available, but not installed
            return View(workDescs);
        }

        public List<string> workDescUsersByTimeEntryID(int timeEntryID)
        {
            List<string> userNames = new List<string>();

            string mainconn = ConfigurationManager.ConnectionStrings["allpaxServiceRecordEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            //begin query for kits available but not installed by machine
            string sqlquery1 = "SELECT tbl_dailyReportTimeEntryUsers.userName " +

            "FROM " +
            "tbl_dailyReportTimeEntryUsers " +
            "WHERE " +
            "tbl_dailyReportTimeEntryUsers.timeEntryID = @timeEntryID";
            //end query for kits available but not installed by machine

            SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn);
            sqlcomm1.Parameters.Add(new SqlParameter("timeEntryID", timeEntryID));           
            SqlDataAdapter sda3 = new SqlDataAdapter(sqlcomm1);
            DataTable dt1 = new DataTable();
            sda3.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                userNames.Add(dr1[0].ToString());
            }
            return userNames;
        }

        //public ActionResult Index(String customerCode, string name, string address, string city, string state)
        //{
        //    ViewBag.customerCode = customerCode;
        //    ViewBag.name = name;
        //    ViewBag.address = address;
        //    ViewBag.city = city;
        //    ViewBag.state = state;

        //    List<machinesW_kitsAvlbl_BnotInstalled> mWkaBni = new List<machinesW_kitsAvlbl_BnotInstalled>();
        //    string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
        //    SqlConnection sqlconn = new SqlConnection(mainconn);

        //    // begin empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables  
        //    //this is handled by a stored procedure on the sql server named dbo.bldSalesOppsTables
        //    sqlconn.Open();
        //    SqlCommand sqlcomm1 = new SqlCommand("dbo.bldSalesOppsTables", sqlconn);
        //    sqlcomm1.CommandType = System.Data.CommandType.StoredProcedure;
        //    sqlcomm1.ExecuteNonQuery();
        //    sqlconn.Close();
        //    //end empty and build custEqpmtWkitsAvlbl and custEqpmtWkitsInstld tables 

        //    //begin query for kits available, but not installed
        //    string sqlquery2 =
        //        "SELECT DISTINCT custEqpmtWkitsAvlbl.customerCode_cEqpmt, custEqpmtWkitsAvlbl.jobNum_cEqpmt, custEqpmtWkitsAvlbl.eqpmtType_cEqpmt, " +
        //        "cmps411.custEqpmtWkitsAvlbl.model_cEqpmt, cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt " +

        //        "FROM cmps411.custEqpmtWkitsAvlbl " +
        //        "LEFT JOIN cmps411.custEqpmtWkitsInstld ON " +
        //        "cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt = cmps411.custEqpmtWkitsInstld.machineID_kitsCurrent " +
        //        "AND cmps411.custEqpmtWkitsAvlbl.kitID_kitsAvlbl = cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent " +
        //        "WHERE " +
        //        "custEqpmtWkitsInstld.machineID_kitsCurrent is NULL " +
        //        "AND " +
        //        "cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent is NULL " +

        //        "AND custEqpmtWkitsAvlbl.customerCode_cEqpmt=@customerCode";

        //    SqlCommand sqlcomm2 = new SqlCommand(sqlquery2, sqlconn);
        //    sqlcomm2.Parameters.AddWithValue("@customerCode", customerCode);
        //    SqlDataAdapter sda2 = new SqlDataAdapter(sqlcomm2);
        //    DataTable dt2 = new DataTable();
        //    sda2.Fill(dt2);
        //    foreach (DataRow dr2 in dt2.Rows)
        //    {
        //        machinesW_kitsAvlbl_BnotInstalled mWkitsAvlblBnotInstalled = new machinesW_kitsAvlbl_BnotInstalled();

        //        mWkitsAvlblBnotInstalled.customerCode = dr2[0].ToString();
        //        mWkitsAvlblBnotInstalled.jobNo = dr2[1].ToString();
        //        mWkitsAvlblBnotInstalled.eqpmtType = dr2[2].ToString();
        //        mWkitsAvlblBnotInstalled.model = dr2[3].ToString();
        //        mWkitsAvlblBnotInstalled.machineID = dr2[4].ToString();
        //        //mWkitsAvlblBnotInstalled.kitsAvlbl_kitID = dr2[5].ToString();
        //        mWkitsAvlblBnotInstalled.kitsAvlblbNotInstld = kitsAvlblbNotInstld(mWkitsAvlblBnotInstalled.customerCode, mWkitsAvlblBnotInstalled.jobNo, mWkitsAvlblBnotInstalled.machineID);

        //        mWkaBni.Add(mWkitsAvlblBnotInstalled);
        //    }

        //    //end query for kits available, but not installed
        //    return View(mWkaBni);
        //}
        //public List<string> kitsAvlblbNotInstld(string customerCode, string jobNo, string machineID)
        //{
        //    List<string> mWkaBni = new List<string>();

        //    string mainconn = ConfigurationManager.ConnectionStrings["allpax_sale_minerEntities"].ConnectionString;
        //    SqlConnection sqlconn = new SqlConnection(mainconn);

        //    //begin query for kits available but not installed by machine
        //    string sqlquery3 = "SELECT custEqpmtWkitsAvlbl.customerCode_cEqpmt, custEqpmtWkitsAvlbl.jobNum_cEqpmt, custEqpmtWkitsAvlbl.eqpmtType_cEqpmt, " +
        //        "cmps411.custEqpmtWkitsAvlbl.model_cEqpmt, cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt, kitID_kitsAvlbl " +
        //        "FROM cmps411.custEqpmtWkitsAvlbl " +
        //        "LEFT JOIN cmps411.custEqpmtWkitsInstld " +
        //        "ON cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt = cmps411.custEqpmtWkitsInstld.machineID_kitsCurrent " +
        //        "AND cmps411.custEqpmtWkitsAvlbl.kitID_kitsAvlbl = cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent " +
        //        "WHERE custEqpmtWkitsInstld.machineID_kitsCurrent is NULL " +
        //        "AND cmps411.custEqpmtWkitsInstld.kitID_kitsCurrent is NULL " +
        //        "AND custEqpmtWkitsAvlbl.customerCode_cEqpmt = @customerCode " +
        //        "AND custEqpmtWkitsAvlbl.jobNum_cEqpmt = @jobNo " +
        //        "AND cmps411.custEqpmtWkitsAvlbl.machineID_cEqpmt = @machineID";
        //    //end query for kits available but not installed by machine

        //    SqlCommand sqlcomm3 = new SqlCommand(sqlquery3, sqlconn);
        //    sqlcomm3.Parameters.Add(new SqlParameter("customerCode", customerCode));
        //    sqlcomm3.Parameters.Add(new SqlParameter("jobNo", jobNo));
        //    sqlcomm3.Parameters.Add(new SqlParameter("machineID", machineID));
        //    SqlDataAdapter sda3 = new SqlDataAdapter(sqlcomm3);
        //    DataTable dt3 = new DataTable();
        //    sda3.Fill(dt3);
        //    foreach (DataRow dr3 in dt3.Rows)
        //    {
        //        mWkaBni.Add(dr3[5].ToString());
        //    }
        //    return mWkaBni;
        //}

        [HttpPost]
        public ActionResult AddWorkDesc(vm_workDesc workDescAdd)
        {

            //db.Database.ExecuteSqlCommand("Insert into tbl_dailyReport Values({0},{1},{2},{3},{4},{5},{6})",
            //   dailyReportAdd.jobID, dailyReportAdd.date, dailyReportAdd.subJobID, dailyReportAdd.startTime, dailyReportAdd.endTime, dailyReportAdd.lunchHours, dailyReportAdd.equipment);

            //--IF THE DAILY REPORT DOESN'T ALREADY EXIST...
            db.Database.ExecuteSqlCommand("IF NOT EXISTS(SELECT * FROM tbl_dailyReportTimeEntry WHERE dailyReportID = {0}) " +
            "BEGIN " +

            "DECLARE @id INT " +
            "DECLARE @timeEntryID INT " +
            "INSERT INTO tbl_dailyReportTimeEntry VALUES({0}, {1}) " +
            "SET @id = SCOPE_IDENTITY() " +
            "INSERT INTO tbl_dailyReportTimeEntryUsers(timeEntryID, userName) VALUES(@id, {2}) " +

            "END " +

            //--IF THE DAILY REPORT DOES ALREADY EXIST...
            "ELSE " +
            "BEGIN " +

            "SET @timeEntryID = " +
                "(SELECT tbl_dailyReportTimeEntry.timeEntryID " +
                "FROM tbl_dailyReportTimeEntry " +
                "WHERE " +

                "tbl_dailyReportTimeEntry.dailyReportID like {0}) " +

                //"INSERT INTO tbl_dailyReportTimeEntryUsers(timeEntryID, userName) VALUES(@timeEntryID, {2}) END)",
                "INSERT INTO tbl_dailyReportTimeEntryUsers(timeEntryID, userName) VALUES(@timeEntryID, {2}) END",


                workDescAdd.dailyReportID, workDescAdd.workDescription, workDescAdd.userNames);

            //db.Database.ExecuteSqlCommand("Insert into tbl_dailyReport Values({0},{1},{2},{3},{4},{5},{6})",
            //   dailyReportAdd.jobID, dailyReportAdd.date, dailyReportAdd.subJobID, dailyReportAdd.startTime, dailyReportAdd.endTime, dailyReportAdd.lunchHours, dailyReportAdd.equipment);

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
