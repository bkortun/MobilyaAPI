using Application.Features.Orders.Models;
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

namespace Application.Features.Orders.Queries.ListOrder
{
    public class ListOrderQueryHandler:IRequestHandler<ListOrderQueryRequest,ListOrderModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ListOrderModel> Handle(ListOrderQueryRequest request, CancellationToken cancellationToken)
        {
           IPaginate<Order> order= await _orderRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, include: p => p.Include(p => p.Basket));
           ListOrderModel listOrderModel = _mapper.Map<ListOrderModel>(order);
            return listOrderModel;
        }
    }
}
