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

namespace Application.Features.UserDetails.Commands.DeleteUserDetail
{
    public class DeleteUserDetailCommandHandler : IRequestHandler<DeleteUserDetailCommandRequest, DeleteUserDetailDto>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public DeleteUserDetailCommandHandler(IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserDetailDto> Handle(DeleteUserDetailCommandRequest request, CancellationToken cancellationToken)
        {
            UserDetail userDetail = _mapper.Map<UserDetail>(request);
            UserDetail mappedUserdetail = await _userDetailRepository.DeleteAsync(userDetail);
            DeleteUserDetailDto deleteUser = _mapper.Map<DeleteUserDetailDto>(mappedUserdetail);
            return deleteUser;

        }
    }
}
