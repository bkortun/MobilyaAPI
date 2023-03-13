using Application.Features.Addresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandle : IRequestHandler<CreateAddressCommandRequest, CreateAddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandle(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreateAddressDto> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            Address mappedAddress = await _addressRepository.AddAsync(address);
            CreateAddressDto createAddressDto = _mapper.Map<CreateAddressDto>(mappedAddress);
            return createAddressDto;
        }
    }
}
