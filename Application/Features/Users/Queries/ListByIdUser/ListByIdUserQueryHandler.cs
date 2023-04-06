using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.ListByIdUser
{
    public class ListByIdUserQueryHandler : IRequestHandler<ListByIdUserQueryRequest, ListByIdUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ListByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ListByIdUserDto> Handle(ListByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            //Todo Business rules will add
            User user = await _userRepository.GetAsync(u => u.Id == Guid.Parse(request.Id));//null check
            ListByIdUserDto listByIdUserDto = _mapper.Map<ListByIdUserDto>(user);
            return listByIdUserDto;
        }
    }
}
