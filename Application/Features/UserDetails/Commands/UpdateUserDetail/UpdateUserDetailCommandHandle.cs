using Application.Features.UserDetails.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Commands.UpdateUserDetail
{
    public class UpdateUserDetailCommandHandle : IRequestHandler<UpdateUserDetailCommandRequest, UpdateUserDetailDto>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserDetailCommandHandle(IUserDetailRepository userDetailRepository, IMapper mapper, IUserRepository userRepository)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UpdateUserDetailDto> Handle(UpdateUserDetailCommandRequest request, CancellationToken cancellationToken)
        {
            
            UserDetail userDetail = _mapper.Map<UserDetail>(request);
            UserDetail UpdatedUserDetail = await _userDetailRepository.UpdateAsync(userDetail);
            UpdateUserDetailDto dto = _mapper.Map<UpdateUserDetailDto>(UpdatedUserDetail);
            return dto;
        }
    }
}
