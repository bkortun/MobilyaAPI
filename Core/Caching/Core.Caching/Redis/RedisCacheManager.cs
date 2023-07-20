using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text;

namespace Core.Caching.Redis
{
    public class RedisCacheManager : ICacheService
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private readonly RedisSettings _redisSettings;
        // readonly CacheSettings _cacheSettings;
        private readonly IDatabase _database;

        public RedisCacheManager(IConfiguration configuration)
        {
            _redisSettings = new();
            _redisSettings.Host = configuration["RedisSettings:Host"];
            _redisSettings.Port = configuration["RedisSettings:Port"];
            _connectionMultiplexer = Connect($"{_redisSettings.Host}:{_redisSettings.Port}");
            _database = _connectionMultiplexer.GetDatabase();
        }

        private ConnectionMultiplexer Connect(string path)
        {
            var options = ConfigurationOptions.Parse(path);
            return ConnectionMultiplexer.Connect(options);
        }

        public async Task AddAsync(string key, byte[] value, TimeSpan? expiringDate)
        {
            await _database.KeyExpireAsync(key, expiringDate);
            await _database.SetAddAsync(key, value);
        }

        public async Task<byte[]> GetAsync(string key)
        {

            var values = await _database.SetMembersAsync(key);
            byte[] bytes = null;
            values.ToList().ForEach(a => bytes = Encoding.Default.GetBytes(a));
            return bytes;
        }

        public byte[] Get(string key)
        {
            var values = _database.SetMembers(key);
            byte[] bytes = null;
            values.ToList().ForEach(a => bytes = Encoding.Default.GetBytes(a));
            return bytes;
        }

        public async Task<bool> IsAddAsync(string key)
        {
            return await _database.KeyExistsAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);

        }
    }
}
