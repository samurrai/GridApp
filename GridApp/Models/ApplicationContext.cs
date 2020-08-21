namespace GridApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HR> HRs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<HR>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<HR>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.HR)
                .WillCascadeOnDelete(false);
        }
    }
}
