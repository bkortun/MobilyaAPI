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

namespace Application.Features.Users.Commands.RemoveOperationClaim
{
    public class RemoveOperationClaimCommandHandler : IRequestHandler<RemoveOperationClaimCommandRequest, RemoveOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public RemoveOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<RemoveOperationClaimDto> Handle(RemoveOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo üstün körü yazıldı, tekrar kontrol edilsin
            UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == Guid.Parse(request.Id));
            UserOperationClaim removedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
            RemoveOperationClaimDto removeOperationClaimDto = new() { Id = removedUserOperationClaim.Id.ToString() };
            return removeOperationClaimDto;
        }
    }
}
