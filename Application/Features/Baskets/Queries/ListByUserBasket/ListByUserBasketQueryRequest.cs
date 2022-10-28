using Application.Features.Baskets.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Queries.ListByUserBasket
{
    public class ListByUserBasketQueryRequest:IRequest<ListByUserBasketDto>
    {
        public string UserId { get; set; }
    }
}
