namespace allpax_service_record.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class allpaxServiceRecordEntities : DbContext
    {
        public allpaxServiceRecordEntities()
            : base("name=allpaxServiceRecordEntities")
        {
        }

        public virtual DbSet<tbl_dailyReport> tbl_dailyReport { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_dailyReport>()
                .Property(e => e.jobID)
                .IsUnicode(false);
        }
    }
}
