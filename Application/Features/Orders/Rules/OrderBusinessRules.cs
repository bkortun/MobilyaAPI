using Application.Services.Repositories;
using Core.Application.BusinessRules;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Rules
{
    public class OrderBusinessRules:BaseBusinessRules<IOrderRepository,Order>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBusinessRules(IOrderRepository orderRepository):base(orderRepository) 
        {
            _orderRepository = orderRepository;
        }
    }
}
