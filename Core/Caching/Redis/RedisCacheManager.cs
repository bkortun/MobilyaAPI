using Core.Application.Pipelines.Caching;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ServiceStack.Diagnostics.Events;

namespace Core.Caching.Redis
{
    public class RedisCacheManager
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private readonly RedisSettings _redisSettings;
        private readonly CacheSettings _cacheSettings;

        public RedisCacheManager(ConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        private void Connect()
        {
            var configString = $"{_redisHost}:{_redisPort}";
            _redis = ConnectionMultiplexer.Connect(configString);
        }
    }
}
