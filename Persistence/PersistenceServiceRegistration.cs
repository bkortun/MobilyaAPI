using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<MobilyaDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            service.AddScoped<IProductRepository,ProductRepository>();

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            service.AddScoped<IBasketRepository, BasketRepository>();
            service.AddScoped<IBasketItemRepository, BasketItemRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();

            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            service.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            service.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            service.AddScoped<IFileRepository,FileRepository>();
            service.AddScoped<IProductImageRepository,ProductImageRepository>();
            service.AddScoped<IImageRepository,ImageRepository>();
            service.AddScoped<ICampaignRepository, CampaignRepository>();

        }
    }
}
