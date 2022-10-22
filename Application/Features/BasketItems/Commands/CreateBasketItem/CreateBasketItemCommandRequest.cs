﻿using Application.Features.BasketItems.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandRequest:IRequest<CreateBasketItemDto>
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string BasketId { get; set; }
        public string Quantity { get; set; }    
    }
}
