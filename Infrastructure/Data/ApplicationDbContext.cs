using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public partial  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<MemberRegistrationDetail> MemberRegistrationDetails { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; }

        public virtual DbSet<TblPayment> TblPayments { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=N1NWPLSK12SQL-v02.shr.prod.ams1.secureserver.net;Database=db_MyPaymentCalculator;User Id=dbo_MyPaymentCalculator;Password=Welcome@123#;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo_MyPaymentCalculator");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11F65C2FD5");

                entity.ToTable("Employee");

                entity.Property(e => e.Department).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<MemberRegistrationDetail>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Password });

                entity.ToTable("Member_Registration_Details", "dbo");

                entity.Property(e => e.UserId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("User_ID");
                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Address).HasColumnType("text");
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasColumnName("Created_by");
                entity.Property(e => e.EmailId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Email_ID");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");
                entity.Property(e => e.IsActive).HasColumnName("Is_Active");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");
                entity.Property(e => e.MemberId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Member_ID");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedDt)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdatedDT");
                entity.Property(e => e.UserType)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("User_Type");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07712BD6FE");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("TBL_CUSTOMER", "dbo");

                entity.Property(e => e.Contact).HasMaxLength(20);
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");
                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");
                entity.Property(e => e.Discount).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.ToTable("TBL_Payment", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AfterDiscount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("After_Discount");
                entity.Property(e => e.CreditAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Credit_Amount");
                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
                entity.Property(e => e.DebitAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Debit_Amount");
                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Discount_amount");
                entity.Property(e => e.IsDiscount).HasColumnName("Is_Discount");
                entity.Property(e => e.ProfitAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Profit_Amount");
                entity.Property(e => e.TransactinDate).HasColumnName("Transactin_Date");
            });
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC07255A4F34");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
                entity.Property(e => e.IsRevoked).HasDefaultValue(false);
                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
  
  }
