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
    public class GetAllProductQueryRequest:IRequest<ListProductsModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
