using Application.Features.BasketItems.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Queries.ListBasketItem
{
    public class ListBasketItemQueryRequest:IRequest<ListBasketItemModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
