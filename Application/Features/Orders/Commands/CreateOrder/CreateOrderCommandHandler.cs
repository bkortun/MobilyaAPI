using Application.Features.Orders.Dtos;
using Application.Services.BasketService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IBasketService basketService, IBasketRepository basketRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _basketService = basketService;
            _basketRepository = basketRepository;
        }

        public async Task<CreateOrderDto> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Basket basket =await _basketRepository.GetAsync(p => p.Id == Guid.Parse(request.BasketId));
            Order addedOrder = await _basketService.CloseBasketAsync(basket);
            CreateOrderDto createOrderDto =_mapper.Map<CreateOrderDto>(addedOrder);
            return createOrderDto;
        }
    }
}
