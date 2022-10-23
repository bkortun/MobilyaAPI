using Application.Features.Orders.Dtos;
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
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderDto> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order=_mapper.Map<Order>(request);
            Order addedOrder = await _orderRepository.AddAsync(order);
            CreateOrderDto createOrderDto =_mapper.Map<CreateOrderDto>(addedOrder);
            return createOrderDto;
        }
    }
}
