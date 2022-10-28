using Application.Features.BasketItems.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Queries.ListByBasket
{
    public class ListByBasketQueryRequest:IRequest<ListByBasketModel>
    {
        public PageRequest PageRequest { get; set; }
        public string BasketId { get; set; }
    }
}
