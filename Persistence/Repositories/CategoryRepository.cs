using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CategoryRepository : EfRepositoryBase<Category, MobilyaDbContext>, ICategoryRepository
    {
        public CategoryRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
