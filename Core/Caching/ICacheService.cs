using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Caching
{
    public interface ICacheService
    {
        Task AddAsync(string key, byte[] value, int duration);
        Task<byte[]> GetAsync(string key);
        byte[] Get(string key);
        Task<bool> IsAddAsync(string key);
        Task RemoveAsync(string key);

    }
}

