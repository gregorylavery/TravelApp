using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using webapi.Models;
namespace webapi.Data 
{
    public class TravelAppDbContext : DbContext
    {
        public TravelAppDbContext()
        {
        }
        public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options)
      : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer(@"Host=database;Username=sa;Password=1q2w#ER%T;Database=TRANSPORTATION");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DBConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public virtual DbSet<TransportationOption> TransportationOptions { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; } 
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
    }
}

