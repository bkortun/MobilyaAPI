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

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommandRequest,UpdateOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderDto> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request);
            Order updatedOrder = await _orderRepository.UpdateAsync(order);
            UpdateOrderDto updateOrderDto = _mapper.Map<UpdateOrderDto>(updatedOrder);
            return updateOrderDto;
        }
    }
}
