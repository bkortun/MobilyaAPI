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

namespace Application.Features.UserDetailAddresses.Commands.DeleteUserDetailAddress
{
    public class DeleteUserDetailAddressCommandHandler : IRequestHandler<DeleteUserDetailAddressCommandRequest, DeleteUserDetailAddressDto>
    {
        private readonly IUserDetailAddressRepository _userDetailAddressRepository;
        private readonly IMapper _mapper;

        public DeleteUserDetailAddressCommandHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserDetailAddressDto> Handle(DeleteUserDetailAddressCommandRequest request, CancellationToken cancellationToken)
        {
            UserDetailAddress userDetailAddress = _mapper.Map<UserDetailAddress>(request);
            UserDetailAddress mappedUserDetailAddress = await _userDetailAddressRepository.DeleteAsync(userDetailAddress);
            DeleteUserDetailAddressDto deleteUserDetailAddressDto = _mapper.Map<DeleteUserDetailAddressDto>(mappedUserDetailAddress);
            return deleteUserDetailAddressDto;
        }
    }
}
