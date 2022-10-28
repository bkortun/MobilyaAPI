using Application.Features.BasketItems.Dtos;
using Application.Services.BasketService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandler:IRequestHandler<UpdateBasketItemCommandRequest,UpdateBasketItemDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public UpdateBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper, IBasketService basketService)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
            _basketService = basketService;
        }

        public async Task<UpdateBasketItemDto> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = _mapper.Map<BasketItem>(request);
            await _basketService.CalculateRemovedBasketItemAsync(basketItem);
            BasketItem updatedBasketItem = await _basketItemRepository.UpdateAsync(basketItem);
            await _basketService.CalculateAddedBasketItemAsync(updatedBasketItem);
            UpdateBasketItemDto updateBasketItemDto = _mapper.Map<UpdateBasketItemDto>(updatedBasketItem);
            return updateBasketItemDto;
        }
    }
}
