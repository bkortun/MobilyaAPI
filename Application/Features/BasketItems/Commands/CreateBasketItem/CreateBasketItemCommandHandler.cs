using Application.Features.BasketItems.Commands.UpdateBasketItem;
using Application.Features.BasketItems.Dtos;
using Application.Features.BasketItems.Rules;
using Application.Services.BasketService;
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

namespace Application.Features.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, CreateBasketItemDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketService _basketService;
        private readonly BasketItemBusinessRules _businessRules;
        private readonly IMapper _mapper;

        public CreateBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper, IBasketService basketService, BasketItemBusinessRules businessRules)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
            _basketService = basketService;
            _businessRules = businessRules;
        }

        public async Task<CreateBasketItemDto> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = _mapper.Map<BasketItem>(request);
            BasketItem addedBasketItem =await _businessRules.UpdateQuantityIfBasketItemIsAvailableAddIfNotAsync(basketItem);
            await _basketService.CalculateAddedBasketItemAsync(addedBasketItem);
            CreateBasketItemDto createBasketItemDto = _mapper.Map<CreateBasketItemDto>(addedBasketItem);
            return createBasketItemDto;
        }
    }
}
