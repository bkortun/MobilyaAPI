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

namespace Application.Features.BasketItems.Queries.ListByBasket
{
    public class ListByBasketQueryHandler : IRequestHandler<ListByBasketQueryRequest, ListByBasketModel>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public ListByBasketQueryHandler(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<ListByBasketModel> Handle(ListByBasketQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<BasketItem> basketItems = await _basketItemRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                predicate: p => p.BasketId == Guid.Parse(request.BasketId), include: p => p.Include(c => c.Product));
            ListByBasketModel listBasketModel = _mapper.Map<ListByBasketModel>(basketItems);
            return listBasketModel;
        }
    }
}
