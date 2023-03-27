using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class ListProductsQueryRequest : IRequest<ListProductModel>
    {
        public PageRequest PageRequest { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
    }
}
