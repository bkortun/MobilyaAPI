using Application.Features.UserDetailAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Commands.CreateUserDetailAddress
{
    public class CreateUserDetailAddressCommandHandler : IRequestHandler<CreateUserDetailAddressCommandRequest, CreateUserDetailAddressDto>
    {
        private readonly IUserDetailAddressRepository _userDetailAddressRepository;
        private readonly IMapper _mapper;

        public CreateUserDetailAddressCommandHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserDetailAddressDto> Handle(CreateUserDetailAddressCommandRequest request, CancellationToken cancellationToken)
        {
            UserDetailAddress userDetailAddress = _mapper.Map<UserDetailAddress>(request);
            UserDetailAddress mappedUserDetailAddress = await _userDetailAddressRepository.AddAsync(userDetailAddress);
            CreateUserDetailAddressDto createUserDetailAddressDto = _mapper.Map<CreateUserDetailAddressDto>(mappedUserDetailAddress);
            return createUserDetailAddressDto;
        }
    }
}
