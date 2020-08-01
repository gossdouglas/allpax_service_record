namespace allpax_service_record.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //public partial class tbl_dailyReport
    //{
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    //    public tbl_dailyReport()
    //    {
    //        tbl_dailyReportTimeEntry = new HashSet<tbl_dailyReportTimeEntry>();
    //        tbl_dailyReportUsers = new HashSet<tbl_dailyReportUsers>();
    //    }

    //    [Required]
    //    [StringLength(8)]
    //    public string jobID { get; set; }

    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int dailyReportID { get; set; }

    //    public DateTime date { get; set; }

    //    public byte subJobID { get; set; }

    //    //public DateTime start { get; set; }
    //    public string startTime { get; set; }

    //    //[Column("_end")]
    //    //public DateTime C_end { get; set; }
    //    public string endTime { get; set; }

    //    public byte lunchHours { get; set; }

    //    public virtual tbl_Jobs tbl_Jobs { get; set; }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    //    public virtual ICollection<tbl_dailyReportTimeEntry> tbl_dailyReportTimeEntry { get; set; }

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    //    public virtual ICollection<tbl_dailyReportUsers> tbl_dailyReportUsers { get; set; }
    //}
}
