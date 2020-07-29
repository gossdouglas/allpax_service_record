namespace allpax_service_record.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_resourceTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_resourceTypes()
        {
            tbl_jobResourceTypes = new HashSet<tbl_jobResourceTypes>();
        }

        [Key]
        public byte resourceTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string resourceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_jobResourceTypes> tbl_jobResourceTypes { get; set; }
    }
}
