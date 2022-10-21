using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProductCategoryRepository : EfRepositoryBase<ProductCategory, MobilyaDbContext>, IProductCategoryRepository
    {
        public ProductCategoryRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
