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

namespace Application.Features.Orders.Commands.CanceledOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommandRequest, CancelOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CancelOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CancelOrderDto> Handle(CancelOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(predicate: c => c.Id == Guid.Parse(request.OrderId));
            order.IsCanceled = true;
            Order updatedOrder = await _orderRepository.UpdateAsync(order);
            CancelOrderDto dto = _mapper.Map<CancelOrderDto>(updatedOrder);
            return dto;
        }
    }
}
