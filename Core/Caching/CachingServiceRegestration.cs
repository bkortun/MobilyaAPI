﻿using Core.Caching.Microsoft;
using Core.Caching.Redis;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching
{
    public static class CachingServiceRegestration
    {
        public static void AddCacheServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
           // services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<ICacheManager, RedisCacheManager>();
        }
    }
}