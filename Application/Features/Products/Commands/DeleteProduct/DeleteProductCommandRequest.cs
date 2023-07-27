using Application.Features.Products.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductDto>,ICacheRemoverRequest
    {
        public string Id { get; set; }

        public bool BypassCache { get; }

        public string CacheKey => "string-list";
    }
}
