﻿using Application.Features.Products.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Domain.Constants.OperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Pipelines.Caching;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<CreateProductDto>,ICacheRemoverRequest//,ISecuredRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public long Stock { get; set; }

        public bool BypassCache { get; }

        public string CacheKey => "product-list";
        // public string[] Roles => new[] { Admin, Add_Product };
    }
}
