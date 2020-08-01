namespace allpax_service_record.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_customers()
        {
            tbl_Jobs = new HashSet<tbl_Jobs>();
        }

        [Key]
        [StringLength(3)]
        public string customerCode { get; set; }

        [Required]
        [StringLength(50)]
        public string customerName { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Jobs> tbl_Jobs { get; set; }
    }
}
