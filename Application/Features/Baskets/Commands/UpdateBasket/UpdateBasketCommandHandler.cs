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

namespace Application.Features.Baskets.Commands.UpdateBasket
{
    public class UpdateBasketCommandHandler:IRequestHandler<UpdateBasketCommandRequest,UpdateBasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UpdateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBasketDto> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            Basket basket = _mapper.Map<Basket>(request);
            Basket updatedBasket=await _basketRepository.UpdateAsync(basket);
            UpdateBasketDto updateBasketDto =_mapper.Map<UpdateBasketDto>(updatedBasket);
            return updateBasketDto;
        }
    }
}
