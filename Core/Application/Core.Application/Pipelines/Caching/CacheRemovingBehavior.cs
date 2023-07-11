using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Caching
{
    public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICacheRemoverRequest
    {
        private readonly IDistributedCache _cache;

        public CacheRemovingBehavior(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;

            if(request.BypassCache)
                return await next();

            response =await GetResponseAndRemoveCache(request,cancellationToken,next);
            return response;
        }

        private async Task<TResponse> GetResponseAndRemoveCache(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = await next();
            await _cache.RemoveAsync(request.CacheKey, cancellationToken);
            return response;
        }
    }
}
