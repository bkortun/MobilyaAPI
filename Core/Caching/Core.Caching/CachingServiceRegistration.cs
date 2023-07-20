using Core.Caching.Microsoft;
using Core.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching
{
    public static class CachingServiceRegistration
    {
        public static void AddCacheServices(this IServiceCollection services)
        {
            //services.AddMemoryCache();
            //services.AddDistributedMemoryCache();
            //services.AddSingleton<ICacheService, DistributedCacheManager>();
            services.AddSingleton<ICacheService, RedisCacheManager>();

        }
    }
}
