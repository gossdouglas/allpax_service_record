namespace allpax_service_record.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Jobs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Jobs()
        {
            tbl_dailyReport = new HashSet<tbl_dailyReport>();
            tbl_jobCorrespondents = new HashSet<tbl_jobCorrespondents>();
            tbl_jobResourceTypes = new HashSet<tbl_jobResourceTypes>();
            tbl_subJobTypes = new HashSet<tbl_subJobTypes>();
        }

        [Key]
        [StringLength(8)]
        public string jobID { get; set; }

        [Required]
        [StringLength(255)]
        public string description { get; set; }

        [Required]
        [StringLength(3)]
        public string customerCode { get; set; }

        [Required]
        [StringLength(50)]
        public string customerContact { get; set; }

        public bool active { get; set; }

        public virtual tbl_customers tbl_customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_dailyReport> tbl_dailyReport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_jobCorrespondents> tbl_jobCorrespondents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_jobResourceTypes> tbl_jobResourceTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_subJobTypes> tbl_subJobTypes { get; set; }
    }
}
