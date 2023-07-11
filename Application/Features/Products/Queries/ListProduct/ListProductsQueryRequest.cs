using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class ListProductsQueryRequest : IRequest<ListProductModel>,ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; }

        public string CacheKey => "product-list";

        public TimeSpan? SlidingExpiration { get; }
    }
}
