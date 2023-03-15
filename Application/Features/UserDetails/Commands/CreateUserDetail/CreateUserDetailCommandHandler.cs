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

namespace Application.Features.UserDetails.Commands.CreateUserDetail
{
    public class CreateUserDetailCommandHandler : IRequestHandler<CreateUserDetailCommandRequest, CreateUserDetailDto>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public CreateUserDetailCommandHandler(IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserDetailDto> Handle(CreateUserDetailCommandRequest request, CancellationToken cancellationToken)
        {
            UserDetail userDetail = _mapper.Map<UserDetail>(request);
            UserDetail mappedUserDetail = await _userDetailRepository.AddAsync(userDetail);
            CreateUserDetailDto createDto = _mapper.Map<CreateUserDetailDto>(mappedUserDetail);
            return createDto;
        }
    }
}
