using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommandRequest,DeleteOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderBusinessRules _businessRules;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRules businessRules)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeleteOrderDto> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order checkedOrder = await _businessRules.CheckRequestedIsNotNull(request.Id);
            Order order = _mapper.Map<Order>(checkedOrder);
            Order deletedOrder = await _orderRepository.DeleteAsync(order);
            DeleteOrderDto deleteOrderDto = _mapper.Map<DeleteOrderDto>(deletedOrder);
            return deleteOrderDto;
        }
    }
}
