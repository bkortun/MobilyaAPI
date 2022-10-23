using Application.Features.Baskets.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Queries.ListBasket
{
    public class ListBasketQueryRequest:IRequest<ListBasketModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
