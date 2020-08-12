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

        public virtual DbSet<tbl_customers> tbl_customers { get; set; }
        public virtual DbSet<tbl_dailyReport> tbl_dailyReport { get; set; }
        public virtual DbSet<tbl_dailyReportUsers> tbl_dailyReportUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_customers>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customers>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customers>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReport>()
                .Property(e => e.jobID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReport>()
                .Property(e => e.equipment)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReportUsers>()
                .Property(e => e.userName)
                .IsUnicode(false);
        }
    }
}
