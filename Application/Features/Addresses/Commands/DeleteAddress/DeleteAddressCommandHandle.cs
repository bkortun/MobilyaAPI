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

namespace Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandle : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public DeleteAddressCommandHandle(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<DeleteAddressDto> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            Address mappedAddress = await _addressRepository.DeleteAsync(address);
            DeleteAddressDto deleteAddressDto = _mapper.Map<DeleteAddressDto>(mappedAddress);
            return deleteAddressDto;
        }
    }
}
