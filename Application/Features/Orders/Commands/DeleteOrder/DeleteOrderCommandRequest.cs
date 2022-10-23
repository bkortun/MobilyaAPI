using Application.Features.Orders.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandRequest:IRequest<DeleteOrderDto>
    {
        public string Id { get; set; }
    }
}
