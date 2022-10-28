using Application.Features.Baskets.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Queries.ListByUserBasket
{
    public class ListByUserBasketQueryHandler : IRequestHandler<ListByUserBasketQueryRequest, ListByUserBasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public ListByUserBasketQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ListByUserBasketDto> Handle(ListByUserBasketQueryRequest request, CancellationToken cancellationToken)
        {
            Basket basket=await _basketRepository.GetAsync(b => b.UserId == Guid.Parse(request.UserId)&&b.IsActive==true);
            ListByUserBasketDto listBasketDto = _mapper.Map<ListByUserBasketDto>(basket);
            return listBasketDto;
        }
    }
}
