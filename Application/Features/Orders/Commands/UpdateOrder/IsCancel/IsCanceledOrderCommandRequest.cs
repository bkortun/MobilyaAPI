using Application.Features.Orders.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder.IsCancel
{
    public class IsCanceledOrderCommandRequest:IRequest<IsCanceledOrderDto>
    {
        public string OrderId { get; set; }
    }
}
