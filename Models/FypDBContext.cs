using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FypDb.Models
{
    public partial class FypDBContext : DbContext
    {
        public FypDBContext()
        {
        }

        public FypDBContext(DbContextOptions<FypDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Bookingstatus> Bookingstatuses { get; set; } = null!;
        public virtual DbSet<Carddetail> Carddetails { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Favourite> Favourites { get; set; } = null!;
        public virtual DbSet<Packagedetail> Packagedetails { get; set; } = null!;
        public virtual DbSet<Paymentstatus> Paymentstatuses { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Servicecategory> Servicecategories { get; set; } = null!;
        public virtual DbSet<Servicetype> Servicetypes { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<Vendorcontactdetail> Vendorcontactdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=FypDB;Username=postgres;Password=7862572");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.HasIndex(e => e.ClientId, "fki_Client_id");

                entity.HasIndex(e => e.PaymentStatus, "fki_Payment_status");

                entity.HasIndex(e => e.ServiceId, "fki_Service_id");

                entity.HasIndex(e => e.VendorId, "fki_Vendor_id");

                entity.HasIndex(e => e.BookingStatus, "fki_b");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BookingStatus).HasColumnName("booking_status");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Time)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("time");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.BookingStatusNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingStatus)
                    .HasConstraintName("Booking_status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Client_id");

                entity.HasOne(d => d.PaymentStatusNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PaymentStatus)
                    .HasConstraintName("Payment_status");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("Service_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("Vendor_id");
            });

            modelBuilder.Entity<Bookingstatus>(entity =>
            {
                entity.ToTable("bookingstatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Carddetail>(entity =>
            {
                entity.ToTable("carddetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CardNo)
                    .HasMaxLength(50)
                    .HasColumnName("card_no");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .HasColumnName("cvv");

                entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");

                entity.Property(e => e.NameOnCard)
                    .HasMaxLength(50)
                    .HasColumnName("name_on_card");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .HasColumnName("phone_no");
            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.ToTable("favourites");

                entity.HasIndex(e => e.ClientId, "fki_client_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("client_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("service_id");
            });

            modelBuilder.Entity<Packagedetail>(entity =>
            {
                entity.ToTable("packagedetails");

                entity.HasIndex(e => e.ServiceId, "fki_service_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Packagedetails)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("service_id");
            });

            modelBuilder.Entity<Paymentstatus>(entity =>
            {
                entity.ToTable("paymentstatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("ratings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Rating1).HasColumnName("rating");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("Service_id");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.HasIndex(e => e.ServiceCategoryId, "fki_Service_category_id");

                entity.HasIndex(e => e.ServiceTypeId, "fki_Service_type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.CapacityMax).HasColumnName("capacity_max");

                entity.Property(e => e.CapacityMin).HasColumnName("capacity_min");

                entity.Property(e => e.Latitude)
                    .HasPrecision(12, 9)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasPrecision(12, 9)
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PriceMax)
                    .HasPrecision(18)
                    .HasColumnName("price_max");

                entity.Property(e => e.PriceMin)
                    .HasPrecision(18)
                    .HasColumnName("price_min");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("service_category_id");

                entity.Property(e => e.ServiceTypeId).HasColumnName("Service_type_id");

                entity.Property(e => e.Services).HasColumnName("services");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("Service_category_id");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .HasConstraintName("Service_type_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("Vendor_id");
            });

            modelBuilder.Entity<Servicecategory>(entity =>
            {
                entity.ToTable("servicecategories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Servicetype>(entity =>
            {
                entity.ToTable("servicetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("Service_category_id");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.Servicetypes)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("Service_category_id");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Vendorcontactdetail>(entity =>
            {
                entity.ToTable("vendorcontactdetails");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(100)
                    .HasColumnName("facebook_id");

                entity.Property(e => e.InstagramId)
                    .HasMaxLength(100)
                    .HasColumnName("instagram_id");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(13)
                    .HasColumnName("phone_no");

                entity.Property(e => e.VendorId).HasColumnName("Vendor_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Vendorcontactdetails)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("Vendor_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
