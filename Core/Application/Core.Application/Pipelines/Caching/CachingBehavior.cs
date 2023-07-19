using Core.Caching;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Caching
{
    //Bunu kullanmak için Requestte ICachableRequest ekleyip implemente etmek yeterli
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICachableRequest
    {
        //IDistributedCache program.cs'de service olarak eklenmeli
        //CacheSettings ve appSettings.json süreyi tutuyor
        private readonly ICacheService _cache;
        private readonly CacheSettings _cacheSettings;

        public CachingBehavior(ICacheService cache, IConfiguration configuration)
        {
            _cache = cache;
            _cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;

            //Bypass edilirse geç
            if (request.BypassCache)
                return await next();

            //Gelen key'de değer var mı
            byte[]? cachedResponse = await _cache.GetAsync(request.CacheKey);
            if (cachedResponse != null)
            {
                //varsa stringe çevir
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            }
            else
            {
                //yoksa cache ekle ve getir
                response = await GetResponseAndAddToCache(request,cancellationToken,next);
            }
            return response;
        }

        private async Task<TResponse> GetResponseAndAddToCache(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //arka planda repository işleminin tamamlanmasını bekliyor
            TResponse response = await next();
            //Time span convert işlemi
            TimeSpan? slidingExpiration = request.SlidingExpiration ?? TimeSpan.FromDays(_cacheSettings.SlidingExpiration);
            //Cache ayarları veriliyor
            DistributedCacheEntryOptions distributedCacheEntryOptions = new() { SlidingExpiration = slidingExpiration };
            //response byte'a çeviriliyor
            byte[] serializedData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            //cache ekleme işlemi
            await _cache.AddAsync(request.CacheKey, serializedData,0);
            return response;
        }
    }
}
