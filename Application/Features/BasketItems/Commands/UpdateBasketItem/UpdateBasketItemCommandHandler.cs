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

namespace Application.Features.BasketItems.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandler:IRequestHandler<UpdateBasketItemCommandRequest,UpdateBasketItemDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public UpdateBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBasketItemDto> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = await _basketItemRepository.GetAsync(b=>b.Id==Guid.Parse(request.Id));
            BasketItem updatedBasketItem = await _basketItemRepository.UpdateAsync(basketItem);
            UpdateBasketItemDto updateBasketItemDto = _mapper.Map<UpdateBasketItemDto>(updatedBasketItem);
            return updateBasketItemDto;
        }
    }
}
