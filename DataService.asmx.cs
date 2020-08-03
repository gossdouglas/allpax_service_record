using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using allpax_service_record.Models.Dropdown_Models;
using allpax_service_record.Models;

namespace allpax_service_record
{
    /// <summary>
    /// Summary description for DataService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DataService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllJobNos()
        {
            string cs = ConfigurationManager.ConnectionStrings["allpaxServiceRecordEntities"].ConnectionString;
            List<dpdwn_jobID> jobIDs = new List<dpdwn_jobID>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllJobNos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_jobID jobID = new dpdwn_jobID();
                    jobID.jobID = rdr["jobID"].ToString();
                    jobIDs.Add(jobID);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(jobIDs));
        }

        [WebMethod]
        public void GetCustomerInfoByJobID(string jobID)
        {
            string cs = ConfigurationManager.ConnectionStrings["allpaxServiceRecordEntities"].ConnectionString;
            List<tbl_customers> customerInfos = new List<tbl_customers>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                con.Open();

                SqlCommand cmd = new SqlCommand("spGetCustomerInfoByJobID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@jobID",
                    Value = jobID
                };
                cmd.Parameters.Add(param);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tbl_customers customerInfo = new tbl_customers();
                    customerInfo.customerCode = rdr["customerCode"].ToString();
                    customerInfo.customerName = rdr["customerName"].ToString();
                    customerInfo.address = rdr["address"].ToString();
                    customerInfos.Add(customerInfo);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(customerInfos));
        }

        [WebMethod]
        public void GetAllTeamNames()
        {
            string cs = ConfigurationManager.ConnectionStrings["allpaxServiceRecordEntities"].ConnectionString;
            List<dpdwn_teamNames> teamNames = new List<dpdwn_teamNames>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTeamNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_teamNames teamName = new dpdwn_teamNames();
                    teamName.name = rdr["name"].ToString();
                    teamName.shortName = rdr["shortName"].ToString();
                    teamNames.Add(teamName);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(teamNames));
        }

        [WebMethod]
        public void GetSubJobTypesByJobID(string jobID)
        {
            string cs = ConfigurationManager.ConnectionStrings["allpaxServiceRecordEntities"].ConnectionString;
            List<dpdwn_SubJobTypes> jobTypes = new List<dpdwn_SubJobTypes>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                con.Open();

                SqlCommand cmd = new SqlCommand("spGetSubJobTypesByJobID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@jobID",
                    Value = jobID
                };
                cmd.Parameters.Add(param);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dpdwn_SubJobTypes jobType = new dpdwn_SubJobTypes();
                    jobType.subJobID = rdr["subJobID"].ToString();
                    jobType.description = rdr["description"].ToString();
                    jobTypes.Add(jobType);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(jobTypes));
        }
    }
}
