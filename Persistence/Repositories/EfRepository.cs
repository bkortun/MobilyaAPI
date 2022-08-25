using Application.Services.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        //Todo: Senkron fonksyonlar eklenecek
        //Todo: Pagination eklenecek
        //Todo: SaveChanges, Table fonksyonun içinde olmalı mı dışında mı???
        //Todo: MobilyaDbContext depandency injection a gerek var mı???

        private readonly MobilyaDbContext _context;

        public EfRepository(MobilyaDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            Table.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            TEntity entity = await Table.SingleOrDefaultAsync(e => e.Id == Guid.Parse(id));
            return Delete(entity);
        }

        public bool DeleteRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,bool tracking = true)
        {
            if (filter==null)
            {
                var query = Table.AsQueryable();
                if (!tracking)
                {
                    query= query.AsNoTracking();
                }
                return query;
            }
            else
            {
                var query=Table.Where(filter);
                if (!tracking)
                {
                    query = query.AsNoTracking();
                }
                return query;
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.SingleOrDefaultAsync(filter);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
