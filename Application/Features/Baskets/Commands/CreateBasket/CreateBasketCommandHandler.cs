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

namespace Application.Features.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, CreateBasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<CreateBasketDto> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            Basket basket = _mapper.Map<Basket>(request);
            Basket addedBasket =await _basketRepository.AddAsync(basket);
            CreateBasketDto createBasketDto =_mapper.Map<CreateBasketDto>(addedBasket);
            return createBasketDto;
        }
    }
}
