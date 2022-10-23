using Application.Features.BasketItems.Dtos;
using Application.Features.BasketItems.Models;
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

namespace Application.Features.BasketItems.Queries.ListBasketItem
{
    public class ListBasketItemQueryHandler : IRequestHandler<ListBasketItemQueryRequest, ListBasketItemModel>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public ListBasketItemQueryHandler(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<ListBasketItemModel> Handle(ListBasketItemQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<BasketItem> basketItems = await _basketItemRepository.GetListAsync(index:request.PageRequest.Page,
                size:request.PageRequest.PageSize,include:p=>p.Include(p=>p.Product));
            ListBasketItemModel listBasketItemModel = _mapper.Map<ListBasketItemModel>(basketItems);
            return listBasketItemModel;
        }
    }
}
