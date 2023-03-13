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

namespace Application.Features.Addresses.Query.ListByIdAddress
{
    public class ListByIdAddressQueryHandler : IRequestHandler<ListByIdAddressQueryRequest, ListByIdAddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public ListByIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ListByIdAddressDto> Handle(ListByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            Address address = await _addressRepository.GetAsync(b => b.Id == Guid.Parse(request.Id));
            ListByIdAddressDto listByIdAddressDto = _mapper.Map<ListByIdAddressDto>(address);
            return listByIdAddressDto;
        }
    }
}
