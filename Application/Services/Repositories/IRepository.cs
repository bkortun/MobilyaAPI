using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public DbSet<T> Table { get; }
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking=true);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(string id);
        bool DeleteRange(List<T> entity);
        Task<int> SaveAsync();
    }
}
