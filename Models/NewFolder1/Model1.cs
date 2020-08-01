namespace allpax_service_record.Models.NewFolder1
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

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tbl_customers> tbl_customers { get; set; }
        public virtual DbSet<tbl_dailyReport> tbl_dailyReport { get; set; }
        public virtual DbSet<tbl_dailyReportTimeEntry> tbl_dailyReportTimeEntry { get; set; }
        public virtual DbSet<tbl_dailyReportTimeEntryUsers> tbl_dailyReportTimeEntryUsers { get; set; }
        public virtual DbSet<tbl_dailyReportUsers> tbl_dailyReportUsers { get; set; }
        public virtual DbSet<tbl_jobCorrespondents> tbl_jobCorrespondents { get; set; }
        public virtual DbSet<tbl_jobResourceTypes> tbl_jobResourceTypes { get; set; }
        public virtual DbSet<tbl_Jobs> tbl_Jobs { get; set; }
        public virtual DbSet<tbl_jobSubJobs> tbl_jobSubJobs { get; set; }
        public virtual DbSet<tbl_resourceTypes> tbl_resourceTypes { get; set; }
        public virtual DbSet<tbl_subJobTypes> tbl_subJobTypes { get; set; }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tbl_customers>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customers>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customers>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customers>()
                .HasMany(e => e.tbl_Jobs)
                .WithRequired(e => e.tbl_customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_dailyReport>()
                .Property(e => e.jobID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReport>()
                .HasMany(e => e.tbl_dailyReportTimeEntry)
                .WithRequired(e => e.tbl_dailyReport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_dailyReport>()
                .HasMany(e => e.tbl_dailyReportUsers)
                .WithRequired(e => e.tbl_dailyReport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_dailyReportTimeEntry>()
                .Property(e => e.workDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReportTimeEntry>()
                .HasMany(e => e.tbl_dailyReportTimeEntryUsers)
                .WithRequired(e => e.tbl_dailyReportTimeEntry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_dailyReportTimeEntryUsers>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dailyReportUsers>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_jobCorrespondents>()
                .Property(e => e.jobID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_jobCorrespondents>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_jobCorrespondents>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_jobResourceTypes>()
                .Property(e => e.jobID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_jobResourceTypes>()
                .Property(e => e.rate)
                .HasPrecision(6, 2);

            modelBuilder.Entity<tbl_Jobs>()
                .Property(e => e.jobID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Jobs>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Jobs>()
                .Property(e => e.customerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Jobs>()
                .Property(e => e.customerContact)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Jobs>()
                .HasMany(e => e.tbl_dailyReport)
                .WithRequired(e => e.tbl_Jobs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Jobs>()
                .HasMany(e => e.tbl_jobCorrespondents)
                .WithRequired(e => e.tbl_Jobs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Jobs>()
                .HasMany(e => e.tbl_jobResourceTypes)
                .WithRequired(e => e.tbl_Jobs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Jobs>()
                .HasMany(e => e.tbl_jobSubJobs)
                .WithRequired(e => e.tbl_Jobs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_jobSubJobs>()
                .Property(e => e.jobID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_resourceTypes>()
                .Property(e => e.resourceType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_resourceTypes>()
                .HasMany(e => e.tbl_jobResourceTypes)
                .WithRequired(e => e.tbl_resourceTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_subJobTypes>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_subJobTypes>()
                .HasOptional(e => e.tbl_jobSubJobs)
                .WithRequired(e => e.tbl_subJobTypes);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.shortName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_dailyReportTimeEntryUsers)
                .WithRequired(e => e.tbl_Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_dailyReportUsers)
                .WithRequired(e => e.tbl_Users)
                .WillCascadeOnDelete(false);
        }
    }
}
