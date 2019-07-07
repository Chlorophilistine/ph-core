namespace Notes.DataAccess
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public interface ICustomerContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Note> Notes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}