using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class TransportationContext : DbContext
{
    public TransportationContext()
    {
    }

    public TransportationContext(DbContextOptions<TransportationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<TransportationOption> TransportationOptions { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=TRANSPORTATION;User Id=sa;Password=Sa_Password:1q2w#ERT!;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKING","TRANSPORTATION");

            entity.Property(e => e.BookingId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BOOKING_ID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymentId).HasColumnName("PAYMENT_ID");
            //entity.Property(e => e.UserLoginId)
            //    .ValueGeneratedOnAdd()
            //    .HasColumnName("USER_LOGIN_ID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PAYMENT", "TRANSPORTATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PAYMENT_ID");
            entity.Property(e => e.PaymentTypeId)
                .HasMaxLength(255)
                .HasColumnName("PAYMENT_TYPE_ID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PAYMENT_TYPE", "TRANSPORTATION");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.PaymentType1)
                .HasMaxLength(255)
                .HasColumnName("PAYMENT_TYPE");
            entity.Property(e => e.PaymentTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PAYMENT_TYPE_ID");
        });

        modelBuilder.Entity<TransportationOption>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TRANSPORTATION_OPTIONS", "TRANSPORTATION");

            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Destination)
                .HasMaxLength(255)
                .HasColumnName("DESTINATION");
            entity.Property(e => e.Duration)
                .HasMaxLength(20)
                .HasColumnName("DURATION");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Origin)
                .HasMaxLength(255)
                .HasColumnName("ORIGIN");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(100)
                .HasColumnName("PROVIDER_NAME");
            entity.Property(e => e.Time).HasColumnName("TIME");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(50)
                .HasColumnName("VEHICLE_TYPE");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USER_LOGINS","TRANSPORTATION");

            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("USER_EMAIL");
            entity.Property(e => e.UserLoginId)
                .ValueGeneratedOnAdd()
                .HasColumnName("USER_LOGIN_ID");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .HasColumnName("USER_PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
