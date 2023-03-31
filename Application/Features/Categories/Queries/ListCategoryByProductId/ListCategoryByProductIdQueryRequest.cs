using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.ListCategoryByProductId
{
    public class ListCategoryByProductIdQueryRequest:IRequest<ListCategoryByProductIdModel>
    {
        public PageRequest PageRequest { get; set; }
        public string ProductId { get; set;}
    }
}
