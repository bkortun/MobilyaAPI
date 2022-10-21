using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrderRepository : EfRepositoryBase<Order, MobilyaDbContext>, IOrderRepository
    {
        public OrderRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
