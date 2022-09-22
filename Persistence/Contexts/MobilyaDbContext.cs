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
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

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
                a.HasMany(p => p.UserOperationClaims);
            });

            modelBuilder.Entity<OperationClaim>(a => {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasMany(p => p.UserOperationClaims);
            });

            modelBuilder.Entity<UserOperationClaim>(a => {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
                a.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                a.HasOne(p => p.User);
                a.HasOne(p => p.OperationClaim);

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
