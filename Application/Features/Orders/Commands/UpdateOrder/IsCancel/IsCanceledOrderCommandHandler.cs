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

namespace Application.Features.Orders.Commands.UpdateOrder.IsCancel
{
    public class IsCanceledOrderCommandHandler : IRequestHandler<IsCanceledOrderCommandRequest, IsCanceledOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public IsCanceledOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IsCanceledOrderDto> Handle(IsCanceledOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(predicate: c => c.Id == Guid.Parse(request.OrderId));
            order.IsCancel = true;
            IsCanceledOrderDto dto = _mapper.Map<IsCanceledOrderDto>(order);
            return dto;
        }
    }
}
