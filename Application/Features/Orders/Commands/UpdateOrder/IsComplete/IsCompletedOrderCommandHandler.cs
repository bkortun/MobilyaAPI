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

namespace Application.Features.Orders.Commands.UpdateOrder.IsComplete
{
    public class IsCompletedOrderCommandHandler : IRequestHandler<IsCompletedOrderCommandRequest, IsCompletedOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public IsCompletedOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IsCompletedOrderDto> Handle(IsCompletedOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(predicate: c => c.Id == Guid.Parse(request.OrderId));
            order.IsComplete = true;
            IsCompletedOrderDto dto = _mapper.Map<IsCompletedOrderDto>(order);
            return dto;
        }
    }
}
