using Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.ListByIdProduct
{
    public class ListByIdProductQueryRequest:IRequest<ListByIdProductDto>
    {
        public string Id { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
    }
}
