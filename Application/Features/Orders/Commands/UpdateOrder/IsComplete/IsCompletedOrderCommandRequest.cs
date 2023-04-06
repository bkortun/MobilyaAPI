using Application.Features.Orders.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder.IsComplete
{
    public class IsCompletedOrderCommandRequest:IRequest<IsCompletedOrderDto>
    {
        public string OrderId { get; set; }
    }
}
