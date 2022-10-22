using Application.Features.BasketItems.Commands.UpdateBasketItem;
using Application.Features.BasketItems.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, CreateBasketItemDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public CreateBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<CreateBasketItemDto> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = _mapper.Map<BasketItem>(request);
            BasketItem addedBasketItem = await _basketItemRepository.AddAsync(basketItem);
            CreateBasketItemDto createBasketItemDto = _mapper.Map<CreateBasketItemDto>(addedBasketItem);
            return createBasketItemDto;
        }
    }
}
