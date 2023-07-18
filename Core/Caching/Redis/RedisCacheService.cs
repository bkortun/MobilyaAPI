using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Text;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly RedisServer _redisServer;
        private readonly IDatabase db;
        private readonly NewtonsoftSerializer _serializer;

        public RedisCacheService(RedisServer redisServer)
        {
            _redisServer = redisServer;
            db = _redisServer.GetId();

            _serializer = new NewtonsoftSerializer();
        }

        public int id { get; private set; }

        public async Task AddAsync(string key, byte[] value, int duration)
        {
            var hashEntries = new HashEntry[]
                {
                    new HashEntry(key, JsonConvert.SerializeObject(value))
                };

            
            await db.HashSetAsync(key, hashEntries);
            
            await db.KeyExpireAsync(key, TimeSpan.FromMinutes(duration));
        }

        public async Task<byte[]> GetAsync(string key, string hashField)
        {
            var hashEntries = new HashEntry[]
            {
                new HashEntry(key,JsonConvert.SerializeObject(hashField))
            };
            var result = await db.HashGetAsync(key, hashField);
            return result;

        }

        public async Task<object> Get(string key,string hashField)
        {
            var hashEntries = new HashEntry[]
            {
                new HashEntry(key,JsonConvert.SerializeObject(hashField))
            };
            var result = await db.HashGetAsync(key,hashField);
            if (result.HasValue)
            {
                return result;

            }
            return null;
        }

        public async Task<bool> IsAdd(string key)
        {
            var result = await db.HashGetAsync($"{key}", "data");
            if (result.HasValue)
            {
                return true;
            }
            return false;
        }

        public async Task Remove(string key)
        {

            await db.HashDeleteAsync(key,"");

        }

        public Task<byte[]> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public byte[] Get(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAddAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
