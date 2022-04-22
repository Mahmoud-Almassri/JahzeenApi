using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.Models.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public partial class JahzeenContext : IdentityDbContext<ApplicationUser, Roles, int, UserClaims, UserRoles, UserLogins, RoleClaims, UserTokens>
    {
        public JahzeenContext()
        {
        }

        public JahzeenContext(DbContextOptions<JahzeenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationExceptions> ApplicationExceptions { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<AppSettings> AppSettings { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyBranches> CompanyBranches { get; set; }
        public virtual DbSet<EmployeeAttachments> EmployeeAttachments { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<UserSkill> UserSkill { get; set; }
        public virtual DbSet<Approvals> Approvals { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }


        AppConfiguration appConfiguration = new AppConfiguration();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationExceptions>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.LoggedInUser).HasMaxLength(50);
            });
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            });


            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });
            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasIndex(e => e.SkillId);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId);
            });
            
            modelBuilder.Entity<Roles>().HasData(
               new Roles { Id=-1,Name="SuperAdmin",NormalizedName="SUPERADMIN" },
               new Roles { Id = -2, Name ="Admin",NormalizedName="ADMIN" },
               new Roles { Id = -3, Name ="DataEntry",NormalizedName="DATAENTRY" },
               new Roles { Id = -4, Name ="Qa",NormalizedName="QA" }
               );
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
