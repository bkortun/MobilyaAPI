using Application.Features.BasketItems.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandRequest:IRequest<DeleteBasketItemDto>
    {
        public string Id { get; set; }
    }
}
