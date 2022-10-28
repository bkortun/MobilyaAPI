using Application.Features.BasketItems.Commands.UpdateBasketItem;
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

namespace Application.Features.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public DeleteBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper, IBasketService basketService)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
            _basketService = basketService;
        }

        public async Task<DeleteBasketItemDto> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = await _basketItemRepository.GetAsync(b=>b.Id==Guid.Parse(request.Id));
            await _basketService.CalculateRemovedBasketItemAsync(basketItem);
            BasketItem deletedBasketItem = await _basketItemRepository.DeleteAsync(basketItem);
            DeleteBasketItemDto deleteBasketItemDto = _mapper.Map<DeleteBasketItemDto>(deletedBasketItem);
            return deleteBasketItemDto;
        }
    }
}
