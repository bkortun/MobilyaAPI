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

namespace Application.Features.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler:IRequestHandler<DeleteBasketCommandRequest,DeleteBasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public DeleteBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<DeleteBasketDto> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            Basket basket = _mapper.Map<Basket>(request);
            Basket deletedBasket=await _basketRepository.DeleteAsync(basket);
            DeleteBasketDto deleteBasketDto =_mapper.Map<DeleteBasketDto>(deletedBasket);
            return deleteBasketDto;
        }
    }
}
