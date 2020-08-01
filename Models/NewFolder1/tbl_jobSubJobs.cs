namespace allpax_service_record.Models.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_jobSubJobs
    {
        [Key]
        public byte subJobID { get; set; }

        [Required]
        [StringLength(8)]
        public string jobID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public virtual tbl_Jobs tbl_Jobs { get; set; }

        public virtual tbl_subJobTypes tbl_subJobTypes { get; set; }
    }
}
