namespace allpax_service_record.Models.MODEL_TESTING
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

        public DateTime date { get; set; }

        public int subJobID { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public int lunchHours { get; set; }

        [Key]
        public int dailyReportID { get; set; }
    }
}
