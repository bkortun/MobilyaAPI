using Application.Features.BasketItems.Dtos;
using Application.Services.BasketService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Commands.UpdateBasketItemQuantity
{
    public class UpdateBasketItemQuantityCommandHandler : IRequestHandler<UpdateBasketItemQuantityCommandRequest, UpdateBasketItemQuantityDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketService _basketService;

        public UpdateBasketItemQuantityCommandHandler(IBasketItemRepository basketItemRepository, IBasketService basketService)
        {
            _basketItemRepository = basketItemRepository;
            _basketService = basketService;
        }

        public async Task<UpdateBasketItemQuantityDto> Handle(UpdateBasketItemQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = await _basketItemRepository.GetAsync(p => p.Id == Guid.Parse(request.Id));
            await _basketService.CalculateRemovedBasketItemAsync(basketItem);
            basketItem.Quantity = request.Quantity;
            BasketItem updatedBasketItem = await _basketItemRepository.UpdateAsync(basketItem);
            await _basketService.CalculateAddedBasketItemAsync(updatedBasketItem);
            UpdateBasketItemQuantityDto updateBasketItemQuantityDto = new()
            {
                Id= updatedBasketItem.Id.ToString(),
                BasketId= updatedBasketItem.BasketId.ToString(),
                ProductId= updatedBasketItem.ProductId.ToString(),
                Quantity= updatedBasketItem.Quantity                
            };
            return updateBasketItemQuantityDto;
        }
    }
}
