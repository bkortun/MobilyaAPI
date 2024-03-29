﻿using Application.Features.Orders.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandRequest:IRequest<UpdateOrderDto>
    {
        public string Id { get; set; }
        public string BasketId { get; set; }
    }
}
