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
    public class CanceledOrderCommandHandler : IRequestHandler<CanceledOrderCommandRequest, CanceledOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CanceledOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CanceledOrderDto> Handle(CanceledOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(predicate: c => c.Id == Guid.Parse(request.OrderId));
            order.Cancel = true;
            Order updatedOrder = await _orderRepository.UpdateAsync(order);
            CanceledOrderDto dto = _mapper.Map<CanceledOrderDto>(updatedOrder);
            return dto;
        }
    }
}
