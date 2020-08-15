namespace allpax_service_record.Models.MODEL_TESTING
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_dailyReportTimeEntry> tbl_dailyReportTimeEntry { get; set; }
        public virtual DbSet<tbl_dailyReportTimeEntryUsers> tbl_dailyReportTimeEntryUsers { get; set; }
        public virtual DbSet<tbl_dailyReportUsers> tbl_dailyReportUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_dailyReportTimeEntry>()
                .Property(e => e.workDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReportTimeEntryUsers>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReportUsers>()
                .Property(e => e.userName)
                .IsUnicode(false);
        }
    }
}
