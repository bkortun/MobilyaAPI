using Application.Features.Baskets.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandRequest:IRequest<CreateBasketDto>
    {
        public string UserId { get; set; }
        public int TotalProduct { get; set; }
        public int TotalPrice { get; set; }
    }
}
