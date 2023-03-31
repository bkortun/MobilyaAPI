using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.ListProductByCategoryId
{
    public class ListProductsByCategoryIdQueryRequest:IRequest<ListProductsByCategoryIdModel>
    {
        public PageRequest PageRequest { get; set; }
        public string CategoryId { get; set; }
    }
}
