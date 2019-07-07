namespace Notes.DataAccess
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
        {
            // finer-grained control of pulling in notes, etc
            //options.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Note> Notes { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Customer>().Property(c => c.Address).HasMaxLength(256);
//            modelBuilder.Entity<Customer>().Property(c => c.Email).HasMaxLength(256);
//            modelBuilder.Entity<Customer>().Property(c => c.Company).HasMaxLength(256);
//
//            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasMaxLength(256).IsRequired();
//            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasMaxLength(256).IsRequired();
//            modelBuilder.Entity<Customer>().Property(c => c.Status).IsRequired();
//        }
    }
}