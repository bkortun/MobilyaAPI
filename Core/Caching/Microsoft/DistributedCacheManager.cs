using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching.Microsoft
{
    public class DistributedCacheManager : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task AddAsync(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            await _distributedCache.SetAsync(key, value, options);
        }

        public async Task<byte[]> GetAsync(string key)
        {
            return await _distributedCache.GetAsync(key);
        }

        public byte[] Get(string key)
        {
            return _distributedCache.Get(key);
        }

        public async Task<bool> IsAddAsync(string key)
        {
            return await _distributedCache.GetAsync(key) == null ? false : true;
        }

        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }


    }


}
