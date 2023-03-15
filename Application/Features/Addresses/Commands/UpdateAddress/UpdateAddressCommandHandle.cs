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

namespace Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandle : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandle(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<UpdateAddressDto> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            Address mappedAddress = await _addressRepository.UpdateAsync(address);
            UpdateAddressDto updateAddressDto = _mapper.Map<UpdateAddressDto>(mappedAddress);
            return updateAddressDto;
        }
    }
}
