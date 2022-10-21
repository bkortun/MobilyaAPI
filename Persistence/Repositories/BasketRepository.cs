using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BasketRepository : EfRepositoryBase<Basket, MobilyaDbContext>, IBasketRepository
    {
        public BasketRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
