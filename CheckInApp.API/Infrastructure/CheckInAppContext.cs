using System.Data.Common;
using CheckInApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckInApp.API.Infrastructure;

public class CheckInAppContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<CheckIn> CheckIns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("CheckInApp");
    }
}