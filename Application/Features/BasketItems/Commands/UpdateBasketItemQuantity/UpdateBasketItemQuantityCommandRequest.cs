using Application.Features.BasketItems.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Commands.UpdateBasketItemQuantity
{
    public class UpdateBasketItemQuantityCommandRequest:IRequest<UpdateBasketItemQuantityDto>
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
    }
}
