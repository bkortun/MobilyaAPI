using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.ListDynamicProduct
{
    public class ListDynamicProductQueryRequest:IRequest<ListProductModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

    }
}
