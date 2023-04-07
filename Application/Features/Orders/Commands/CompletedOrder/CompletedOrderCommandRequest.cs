using Application.Features.Orders.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CompletedOrder
{
    public class CompletedOrderCommandRequest : IRequest<CompletedOrderDto>
    {
        public string OrderId { get; set; }
    }
}
