using Application.Features.Baskets.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketCommandRequest:IRequest<DeleteBasketDto>
    {
        public string Id { get; set; }
    }
}
