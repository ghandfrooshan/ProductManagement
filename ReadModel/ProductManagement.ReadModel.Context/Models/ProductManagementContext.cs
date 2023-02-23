using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.ReadModel.Context.Models;

public partial class ProductManagementContext : DbContext
{
    public ProductManagementContext()
    {
    }

    public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<ProductProperty> ProductProperties { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server =.; initial catalog = ProductManagement; integrated security = false;User ID=sa;Password='921';MultipleActiveResultSets=True; Application Name =  ProductManagementApp;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency", "ProductContext");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "ProductContext");

            entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [shared].[Product])");
            entity.Property(e => e.IsActice)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(1)))");
            entity.Property(e => e.Name).HasMaxLength(300);

            entity.HasOne(d => d.Category).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory", "ProductContext");

            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.ToTable("ProductPrice");

            entity.HasIndex(e => e.CurrencyId, "IX_ProductPrice_CurrencyId").IsUnique();

            entity.HasIndex(e => e.ProductId, "IX_ProductPrice_ProductId");

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [shared].[ProductPrice])");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.Currency).WithOne(p => p.ProductPrice)
                .HasForeignKey<ProductPrice>(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPrices).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<ProductProperty>(entity =>
        {
            entity.ToTable("ProductProperty");

            entity.HasIndex(e => e.ProductId, "IX_ProductProperty_ProductId");

            entity.HasIndex(e => e.PropertyId, "IX_ProductProperty_PropertyId").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [shared].[ProductProperty])");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductProperties).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Property).WithOne(p => p.ProductProperty)
                .HasForeignKey<ProductProperty>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.ToTable("Property", "ProductContext");

            entity.Property(e => e.Name).HasMaxLength(250);
        });
        modelBuilder.HasSequence("Product", "Shared");
        modelBuilder.HasSequence("ProductPrice", "Shared");
        modelBuilder.HasSequence("ProductProperty", "Shared");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
