using Application.Features.Orders.Models;
using Application.Features.Orders.Queries.ListOrder;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.ListByUserId
{
    public class ListByUserIdOrderQueryHandler : IRequestHandler<ListByUserIdOrderQueryRequest, ListByUserIdOrderModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ListByUserIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ListByUserIdOrderModel> Handle(ListByUserIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Order> orders = await _orderRepository.GetListAsync(predicate: o => o.Basket.UserId == Guid.Parse(request.UserId), include: p => p.Include(p => p.Basket));
            ListByUserIdOrderModel listOrderModel = _mapper.Map<ListByUserIdOrderModel>(orders);
            return listOrderModel;
        }
    }
}
