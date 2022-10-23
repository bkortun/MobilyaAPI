using Application.Features.Baskets.Models;
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

namespace Application.Features.Baskets.Queries.ListBasket
{
    public class ListBasketQueryHandler:IRequestHandler<ListBasketQueryRequest,ListBasketModel>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public ListBasketQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ListBasketModel> Handle(ListBasketQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Basket> baskets =await _basketRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize,
                include:p=>p.Include(p=>p.User));
            ListBasketModel listBasketModel=_mapper.Map<ListBasketModel>(baskets);
            return listBasketModel;
        }
    }
}
