namespace allpax_service_record.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_dailyReportTimeEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_dailyReportTimeEntry()
        {
            tbl_dailyReportTimeEntryUsers = new HashSet<tbl_dailyReportTimeEntryUsers>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte timeEntryID { get; set; }

        public int dailyReportID { get; set; }

        [Required]
        [StringLength(1024)]
        public string workDescription { get; set; }

        public virtual tbl_dailyReport tbl_dailyReport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_dailyReportTimeEntryUsers> tbl_dailyReportTimeEntryUsers { get; set; }
    }
}
