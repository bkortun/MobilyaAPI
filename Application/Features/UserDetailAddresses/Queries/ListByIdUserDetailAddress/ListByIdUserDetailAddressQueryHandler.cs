using Application.Features.UserDetailAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Queries.ListByIdUserDetailAddress
{
    public class ListByIdUserDetailAddressQueryHandler : IRequestHandler<ListByIdUserDetailAddressQueryRequest, ListByIdUserDetailAddressDto>
    {
        private readonly IUserDetailAddressRepository _userDetailAddressRepository;
        private readonly IMapper _mapper;

        public ListByIdUserDetailAddressQueryHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
        }

        public Task<ListByIdUserDetailAddressDto> Handle(ListByIdUserDetailAddressQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
