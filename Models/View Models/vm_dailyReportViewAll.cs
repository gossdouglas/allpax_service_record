namespace allpax_service_record.Models.View_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vm_dailyReportViewAll
    {
        public int dailyReportID { get; set; }

        public Boolean active { get; set; }

        public DateTime date { get; set; }

        public string jobID { get; set; }

        //public string subJobDescription { get; set; }

        public string description { get; set; }

        public string customerName { get; set; }

        public string location { get; set; }

        public int subJobID { get; set; }

        public string team { get; set; }

        public string workDescription { get; set; }    
       
    }
}
