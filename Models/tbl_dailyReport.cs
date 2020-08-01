namespace allpax_service_record.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_dailyReport
    {
        [Required]
        [StringLength(8)]
        public string jobID { get; set; }

        //public DateTime date { get; set; }
        public string date { get; set; }

        public string subJobID { get; set; }

        //public DateTime startTime { get; set; }
        public string startTime { get; set; }

        //public DateTime endTime { get; set; }
        public string endTime { get; set; }

        public string lunchHours { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dailyReportID { get; set; }
    }
}
