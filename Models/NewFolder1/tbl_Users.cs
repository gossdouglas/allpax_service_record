namespace allpax_service_record.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Users()
        {
            tbl_dailyReportTimeEntryUsers = new HashSet<tbl_dailyReportTimeEntryUsers>();
            tbl_dailyReportUsers = new HashSet<tbl_dailyReportUsers>();
        }

        [Key]
        [StringLength(16)]
        public string userName { get; set; }

        [Required]
        [StringLength(16)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(8)]
        public string shortName { get; set; }

        public bool admin { get; set; }

        public bool active { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_dailyReportTimeEntryUsers> tbl_dailyReportTimeEntryUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_dailyReportUsers> tbl_dailyReportUsers { get; set; }
    }
}
