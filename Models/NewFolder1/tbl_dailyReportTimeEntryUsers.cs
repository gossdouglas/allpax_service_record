namespace allpax_service_record.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_dailyReportTimeEntryUsers
    {
        [Key]
        [Column(Order = 0)]
        public byte timeEntryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string userName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public virtual tbl_dailyReportTimeEntry tbl_dailyReportTimeEntry { get; set; }

        public virtual tbl_Users tbl_Users { get; set; }
    }
}
