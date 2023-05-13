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

namespace Application.Features.Orders.Commands.CompletedOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CompleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CompleteOrderDto> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(predicate: c => c.Id == Guid.Parse(request.OrderId));
            order.IsCompleted = true;
            Order updatedOrder = await _orderRepository.UpdateAsync(order);
            CompleteOrderDto dto = _mapper.Map<CompleteOrderDto>(updatedOrder);
            return dto;
        }
    }
}
