using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BasketItemRepository : EfRepositoryBase<BasketItem, MobilyaDbContext>, IBasketItemRepository
    {
        public BasketItemRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
