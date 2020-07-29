namespace allpax_service_record.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_subJobTypes
    {
        [Key]
        public byte subJobID { get; set; }

        [Required]
        [StringLength(16)]
        public string description { get; set; }

        public virtual tbl_Jobs tbl_Jobs { get; set; }
    }
}
