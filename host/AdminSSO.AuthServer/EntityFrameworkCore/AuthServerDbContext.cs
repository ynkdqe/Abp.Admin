using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.UserOtps;
using AdminSSO.Users;
using AdminSSO.Wards;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace AdminSSO.EntityFrameworkCore;

public class AuthServerDbContext : AbpDbContext<AuthServerDbContext>
{
    public AuthServerDbContext(DbContextOptions<AuthServerDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigurePermissionManagement();
        //modelBuilder.ConfigureSettingManagement();
        //modelBuilder.ConfigureAuditLogging();
        //modelBuilder.ConfigureIdentity();
        //modelBuilder.ConfigureOpenIddict();
        //modelBuilder.ConfigureFeatureManagement();
        //modelBuilder.ConfigureTenantManagement();

        modelBuilder.ConfigureAdminSSO();

        //modelBuilder.ConfigureTenantManagement();

        //modelBuilder.Entity<City>(entity =>
        //{
        //    entity.ToTable("City");
        //    entity.Property(e => e.DateCreated)
        //        .HasColumnType("datetime")
        //        .HasDefaultValueSql("(getdate())");

        //    entity.Property(e => e.Description).HasMaxLength(250);

        //    entity.Property(e => e.GroupLocation).HasMaxLength(50);

        //    entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

        //    entity.Property(e => e.Name).HasMaxLength(250);

        //    entity.Property(e => e.NameAscii)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<District>(entity =>
        //{
        //    entity.ToTable("District");
        //    entity.Property(e => e.DateCreated)
        //        .HasColumnType("datetime")
        //        .HasDefaultValueSql("(getdate())");

        //    entity.Property(e => e.Desciption).HasMaxLength(250);

        //    entity.Property(e => e.Name).HasMaxLength(250);

        //    entity.Property(e => e.NameAscii)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<Ward>(entity =>
        //{
        //    entity.ToTable("Ward");
        //    entity.Property(e => e.DateCreated)
        //        .HasColumnType("datetime")
        //        .HasDefaultValueSql("(getdate())");

        //    entity.Property(e => e.Description).HasMaxLength(250);

        //    entity.Property(e => e.Name).HasMaxLength(250);

        //    entity.Property(e => e.NameAscii)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<UserOtp>(entity =>
        //{
        //    entity.ToTable("UserOtp");
        //    entity.Property(e => e.DateActive).HasColumnType("datetime");

        //    entity.Property(e => e.DateCreated)
        //        .HasColumnType("datetime")
        //        .HasDefaultValueSql("(getdate())");

        //    entity.Property(e => e.DateExpired).HasColumnType("datetime");

        //    entity.Property(e => e.OtpCode)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.UserCode)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<User>(entity =>
        //{
        //    entity.ToTable("User");
        //    entity.Property(e => e.Id).HasColumnName("ID");

        //    entity.Property(e => e.Address).HasMaxLength(100);

        //    entity.Property(e => e.Avatar).HasMaxLength(500);

        //    entity.Property(e => e.Birthday).HasColumnType("datetime");

        //    entity.Property(e => e.CitizenIdentificationNo)
        //        .HasMaxLength(12)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DateCreated).HasColumnType("datetime");

        //    entity.Property(e => e.Email)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);

        //    entity.Property(e => e.FirstName).HasMaxLength(50);
        //    entity.Property(e => e.Password)
        //    .HasMaxLength(50)
        //    .IsUnicode(false);
        //    entity.Property(e => e.PasswordSalt)
        //    .HasMaxLength(100)
        //    .IsUnicode(false);

        //    entity.Property(e => e.IdentityNo)
        //        .HasMaxLength(9)
        //        .IsUnicode(false);

        //    entity.Property(e => e.LastChangedPasswordDate).HasColumnType("datetime");

        //    entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

        //    entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

        //    entity.Property(e => e.LastName).HasMaxLength(50);

        //    entity.Property(e => e.ModifierDate).HasColumnType("datetime");

        //    entity.Property(e => e.Name).HasMaxLength(50);

        //    entity.Property(e => e.Phone)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);

        //    entity.Property(e => e.UserCode)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.UserName)
        //        .HasMaxLength(30)
        //        .IsUnicode(false);
        //});
    }
}
