using Application.Services.BasketService;
using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Rules
{
    public class BasketItemBusinessRules
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketService _basketService;

        public BasketItemBusinessRules(IBasketItemRepository basketItemRepository, IBasketService basketService)
        {
            _basketItemRepository = basketItemRepository;
            _basketService = basketService;
        }

        public async Task<BasketItem> UpdateQuantityIfBasketItemIsAvailableAddIfNotAsync(BasketItem basketItem)
        {
           BasketItem existBasketItem=await _basketItemRepository.GetAsync(b => b.ProductId == basketItem.ProductId&&b.BasketId==basketItem.BasketId);
            if (existBasketItem != null)
            {
                await _basketService.CalculateRemovedBasketItemAsync(existBasketItem);
                existBasketItem.Quantity += basketItem.Quantity;
                return await _basketItemRepository.UpdateAsync(existBasketItem);
            }
            else
            {
                return await _basketItemRepository.AddAsync(basketItem);
            }
        }
    }
}
