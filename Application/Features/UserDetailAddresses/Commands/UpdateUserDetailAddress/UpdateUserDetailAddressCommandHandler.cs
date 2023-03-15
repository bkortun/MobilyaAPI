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

namespace Application.Features.UserDetailAddresses.Commands.UpdateUserDetailAddress
{
    public class UpdateUserDetailAddressCommandHandler : IRequestHandler<UpdateUserDetailAddressCommandRequest, UpdateUserDetailAddressDto>
    {
        private readonly IUserDetailAddressRepository _userDetailAddressRepository;
        private readonly IMapper _mapper;

        public UpdateUserDetailAddressCommandHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserDetailAddressDto> Handle(UpdateUserDetailAddressCommandRequest request, CancellationToken cancellationToken)
        {
            UserDetailAddress userDetailAddress = _mapper.Map<UserDetailAddress>(request);
            UserDetailAddress mappedUserDetailAddress = await _userDetailAddressRepository.UpdateAsync(userDetailAddress);
            UpdateUserDetailAddressDto updateDto = _mapper.Map<UpdateUserDetailAddressDto>(mappedUserDetailAddress);
            return updateDto;
        }
    }
}
