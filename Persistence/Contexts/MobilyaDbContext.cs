using Core.Persistence.Repositories;
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

        // Todo Status'ün başlangıç değeri true olarak ayarlanıcak
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
                a.Property(p => p.Status).HasColumnName("Status");
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Entity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
                return base.SaveChangesAsync(cancellationToken);
        }


    }
}
