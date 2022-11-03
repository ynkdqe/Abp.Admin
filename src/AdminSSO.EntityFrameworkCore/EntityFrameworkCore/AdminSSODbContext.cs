using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.UserOtps;
using AdminSSO.Users;
using AdminSSO.Wards;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AdminSSO.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AdminSSODbContext :
    AbpDbContext<AdminSSODbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ward> Wards { get; set; }
    public DbSet<UserOtp> UserOtps { get; set; }
    public DbSet<User> Users { get; set; }

    #endregion

    public AdminSSODbContext(DbContextOptions<AdminSSODbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AdminSSOConsts.DbTablePrefix + "YourEntities", AdminSSOConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<City>(entity =>
        {
            entity.ToTable("City");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description).HasMaxLength(250);

            entity.Property(e => e.GroupLocation).HasMaxLength(50);

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.Property(e => e.NameAscii)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        builder.Entity<District>(entity =>
        {
            entity.ToTable("District");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Desciption).HasMaxLength(250);

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.Property(e => e.NameAscii)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        builder.Entity<Ward>(entity =>
        {
            entity.ToTable("Ward");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description).HasMaxLength(250);

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.Property(e => e.NameAscii)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        builder.Entity<UserOtp>(entity =>
        {
            entity.ToTable("UserOtp");
            entity.Property(e => e.DateActive).HasColumnType("datetime");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.DateExpired).HasColumnType("datetime");

            entity.Property(e => e.OtpCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.UserCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        builder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Address).HasMaxLength(100);

            entity.Property(e => e.Avatar).HasMaxLength(500);

            entity.Property(e => e.Birthday).HasColumnType("datetime");

            entity.Property(e => e.CitizenIdentificationNo)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.FullName).HasMaxLength(50);

            entity.Property(e => e.IdentityNo)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.Property(e => e.LastChangedPasswordDate).HasColumnType("datetime");

            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.ModifierDate).HasColumnType("datetime");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.UserCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });
    }
}
