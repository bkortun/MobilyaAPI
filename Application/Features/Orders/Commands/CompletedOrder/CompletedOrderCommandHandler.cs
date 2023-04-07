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
    public class CompletedOrderCommandHandler : IRequestHandler<CompletedOrderCommandRequest, CompletedOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CompletedOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CompletedOrderDto> Handle(CompletedOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(predicate: c => c.Id == Guid.Parse(request.OrderId));
            order.Complete = true;
            Order updatedOrder = await _orderRepository.UpdateAsync(order);
            CompletedOrderDto dto = _mapper.Map<CompletedOrderDto>(updatedOrder);
            return dto;
        }
    }
}
