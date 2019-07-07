namespace Notes.DataAccess
{
    using System;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Address).HasMaxLength(256);
            modelBuilder.Entity<Customer>().Property(c => c.Email).HasMaxLength(256);
            modelBuilder.Entity<Customer>().Property(c => c.Company).HasMaxLength(256);

            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Status).IsRequired();

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            // add customers
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                Status = Status.Prospective,
                Created = new DateTime(2019, 2, 12),
                FirstName = "Joe",
                LastName = "Bloggs",
                Company = "Amalgamated Holdings",
                Email = "joe@bloggs.com",
                Address = "1 High Street, Edinburgh"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                Status = Status.Current,
                Created = new DateTime(2010, 12, 12),
                FirstName = "Andrea",
                LastName = "Smith",
                Company = "SoleTrader LLP",
                Email = "a@smith.com",
                Address = "456 High Street, Edinburgh"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 3,
                Status = Status.NonActive,
                Created = new DateTime(1999, 1, 1),
                FirstName = "Zachry",
                LastName = "Twist",
                Company = "Twist Incorporated",
                Email = "z@twist.com",
                Address = "29 Acacia Road, Edinburgh"
            });

            // add notes
            modelBuilder.Entity<Note>().HasData(new Note { Id = 1, CustomerId = 1, Content = "My first note"});
            modelBuilder.Entity<Note>().HasData(new Note { Id = 2, CustomerId = 1, Content = "Prospective customer, follow up on lead" });
            modelBuilder.Entity<Note>().HasData(new Note { Id = 3, CustomerId = 2, Content = "Current customer, due quarterly sales review" });
            modelBuilder.Entity<Note>().HasData(new Note { Id = 4, CustomerId = 2, Content = "For review" });
            modelBuilder.Entity<Note>().HasData(new Note { Id = 5, CustomerId = 2, Content = "Sales order follow up" });        }
        }
    }