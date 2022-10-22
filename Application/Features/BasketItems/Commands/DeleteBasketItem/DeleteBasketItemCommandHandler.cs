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

namespace Application.Features.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemDto>
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public DeleteBasketItemCommandHandler(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBasketItemDto> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = await _basketItemRepository.GetAsync(b=>b.Id==Guid.Parse(request.Id));
            BasketItem deletedBasketItem = await _basketItemRepository.DeleteAsync(basketItem);
            DeleteBasketItemDto deleteBasketItemDto = _mapper.Map<DeleteBasketItemDto>(deletedBasketItem);
            return deleteBasketItemDto;
        }
    }
}
