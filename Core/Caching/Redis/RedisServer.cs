using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching.Redis
{
    public class RedisServer
    {
        private readonly string _redisHost;
        private readonly string _redisPort;
        private ConnectionMultiplexer _redis;
        private IDatabase db { get; set; }

        public RedisServer(IConfiguration configuration)
        {

            _redisHost = configuration["Redis:Host"];
            _redisPort = configuration["Redis:Port"];

            Connect();
        }

        public void Connect()
        {
            var configString = $"{_redisHost}:{_redisPort}";
            _redis = ConnectionMultiplexer.Connect(configString);
        }

        public IDatabase GetId(int db)
        {
            return _redis.GetDatabase(db);
        }
    }
}
