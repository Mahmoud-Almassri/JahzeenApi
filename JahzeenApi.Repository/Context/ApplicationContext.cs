//using JahzeenApi.Domain.Models;
//using JahzeenApi.Domain.Models.Common;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Repository.Context
//{
//    public partial class ApplicationContext : IdentityDbContext<ApplicationUser, Roles, int, UserClaims, UserRoles, UserLogins, RoleClaims, UserTokens>
//    {

//        public ApplicationContext()
//        {
//            ChangeTracker.LazyLoadingEnabled = false;
//        }

//        public ApplicationContext(DbContextOptions<ApplicationContext> options)
//            : base(options)
//        {
//            ChangeTracker.LazyLoadingEnabled = false;
//        }

//        public virtual DbSet<ApplicationExceptions> ApplicationExceptions { get; set; }
//        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
//        public virtual DbSet<BusinecityDomainValues> BusinecityDomainValues { get; set; }
//        public virtual DbSet<BusinecityDomains> BusinecityDomains { get; set; }


//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            AppConfiguration appConfiguration = new AppConfiguration();
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
//            }

//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<ApplicationExceptions>(entity =>
//            {
//                entity.Property(e => e.DateTime).HasColumnType("datetime");

//                entity.Property(e => e.LoggedInUser).HasMaxLength(50);
//            });

//            modelBuilder.Entity<ApplicationUser>(entity =>
//            {
//                entity.Property(e => e.CreatedBy).HasMaxLength(50);

//                entity.Property(e => e.CreationDate).HasColumnType("datetime");

//                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

//                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
//            });

           


//            modelBuilder.Entity<RoleClaims>(entity =>
//            {
//                entity.HasIndex(e => e.RoleId);

//                entity.HasOne(d => d.Role)
//                    .WithMany(p => p.RoleClaims)
//                    .HasForeignKey(d => d.RoleId);
//            });

//            modelBuilder.Entity<Roles>(entity =>
//            {
//                entity.HasIndex(e => e.NormalizedName)
//                    .HasName("RoleNameIndex")
//                    .IsUnique()
//                    .HasFilter("([NormalizedName] IS NOT NULL)");

//                entity.Property(e => e.Name).HasMaxLength(256);

//                entity.Property(e => e.NormalizedName).HasMaxLength(256);
//            });

//            modelBuilder.Entity<BusinecityDomainValues>(entity =>
//            {
//                entity.Property(e => e.ArStringValue).HasMaxLength(50);

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50);

//                entity.Property(e => e.StringValue).HasMaxLength(50);

//                entity.HasOne(d => d.DomainCodeNavigation)
//                    .WithMany(p => p.BusinecityDomainValues)
//                    .HasPrincipalKey(p => p.Code)
//                    .HasForeignKey(d => d.DomainCode)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_BusinecityDomainValues_BusinecityDomains");
//            });

//            modelBuilder.Entity<BusinecityDomains>(entity =>
//            {
//                entity.HasIndex(e => e.Code)
//                    .HasName("Unique_BusinecityDomains")
//                    .IsUnique();

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50);
//            });

//            modelBuilder.Entity<UserClaims>(entity =>
//            {
//                entity.HasIndex(e => e.UserId);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.UserClaims)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<UserLogins>(entity =>
//            {
//                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

//                entity.HasIndex(e => e.UserId);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.UserLogins)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<UserRoles>(entity =>
//            {
//                entity.HasKey(e => new { e.UserId, e.RoleId });

//                entity.HasIndex(e => e.RoleId);

//                entity.HasOne(d => d.Role)
//                    .WithMany(p => p.UserRoles)
//                    .HasForeignKey(d => d.RoleId);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.UserRoles)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<UserTokens>(entity =>
//            {
//                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.UserTokens)
//                    .HasForeignKey(d => d.UserId);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}