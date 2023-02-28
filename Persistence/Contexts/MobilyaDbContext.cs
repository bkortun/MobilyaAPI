using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class MobilyaDbContext : DbContext
    {
        public MobilyaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Price).HasColumnName("Price");
                a.Property(p => p.Stock).HasColumnName("Stock");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p=>p.ProductImages).WithOne(p=>p.Product).HasForeignKey(p=>p.ProductId);
                a.HasMany(p => p.ProductCategories).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<Category>(a =>
            {
                a.ToTable("Categories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p => p.ProductCategories).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<ProductCategory>(a =>
            {
                a.ToTable("ProductCategories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProductId).HasColumnName("ProductId");
                a.Property(p => p.CategoryId).HasColumnName("CategoryId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Category).WithMany(p => p.ProductCategories).HasForeignKey(p => p.CategoryId);
                a.HasOne(p => p.Product).WithMany(p => p.ProductCategories).HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p => p.UserOperationClaims).WithOne(p=>p.User).HasForeignKey(p=>p.UserId);
                a.HasMany(p => p.RefreshTokens).WithOne(p=>p.User).HasForeignKey(p=>p.UserId);
            });

            modelBuilder.Entity<OperationClaim>(a => {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
            });

            modelBuilder.Entity<UserOperationClaim>(a => {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.User).WithMany(p=>p.UserOperationClaims).HasForeignKey(p=>p.UserId);
            });

            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status");
                a.HasOne(u => u.User);
            });

            modelBuilder.Entity<Domain.Entities.File>(a => {
                a.ToTable("Files").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Path).HasColumnName("Path");
                a.Property(p => p.Storage).HasColumnName("Storage");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Ignore(p=>p.UpdatedDate);
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Image).WithOne(p => p.File).HasForeignKey<Image>(p=>p.FileId);
            });

            modelBuilder.Entity<Image>(a => {
                a.ToTable("Images").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FileId).HasColumnName("FileId");
                a.Property(p => p.Showcase).HasColumnName("Showcase");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p=>p.File).WithOne(p=>p.Image).HasForeignKey<Image>(p => p.FileId);
                a.HasMany(p=>p.ProductImages).WithOne(p=>p.Image).HasForeignKey(p=>p.ImageId);
            });

            modelBuilder.Entity<ProductImage>(a =>
            {
                a.ToTable("ProductImages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProductId).HasColumnName("ProductId");
                a.Property(p => p.ImageId).HasColumnName("ImageId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p=>p.Image).WithMany(p=>p.ProductImages).HasForeignKey(p=>p.ImageId);
                a.HasOne(p=>p.Product).WithMany(p=>p.ProductImages).HasForeignKey(p=>p.ProductId);
            });

            modelBuilder.Entity<Basket>(a =>
            {
                a.ToTable("Baskets").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.TotalProduct).HasColumnName("TotalProduct");
                a.Property(p => p.TotalPrice).HasColumnName("TotalPrice");
                a.Property(p => p.CreatedDate).HasColumnName("CreateDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Order).WithOne(p => p.Basket).HasForeignKey<Order>(p => p.BasketId);
                a.HasOne(p => p.User);
                a.HasMany(p => p.BasketItems).WithOne(p => p.Basket).HasForeignKey(p => p.BasketId);
            });

            modelBuilder.Entity<BasketItem>(a =>
            {
                a.ToTable("BasketItems").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProductId).HasColumnName("ProductId");
                a.Property(p => p.BasketId).HasColumnName("BasketId");
                a.Property(p => p.Quantity).HasColumnName("Quantity");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Basket).WithMany(p => p.BasketItems).HasForeignKey(p => p.BasketId);
                a.HasOne(p => p.Product).WithMany(p => p.BasketItems).HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<Order>(a =>
            {
                a.ToTable("Orders").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.BasketId).HasColumnName("BasketId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.Basket).WithOne(p => p.Order).HasForeignKey<Order>(p => p.BasketId);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Entity>();

            foreach (var data in datas)
            {
                if (data.State==EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                }
                if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.UtcNow;
                }
                //Todo status false yapılcak silinme yerine
                /*if (data.State == EntityState.Deleted)
                {
                    data.Entity.Status = false;
                }*/
            }
                return base.SaveChangesAsync(cancellationToken);
        }


    }
}
