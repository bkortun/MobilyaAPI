using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.AddOperationClaim
{
    public class AddOperationClaimCommandHandler : IRequestHandler<AddOperationClaimCommandRequest, AddOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public AddOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<AddOperationClaimDto> Handle(AddOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo entity mevcutmu kontrolü yapılacak
            User user=await _userRepository.GetAsync(u => u.Email == request.Email);
            OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Name == request.OperationClaimName);
            UserOperationClaim userOperationClaim = new()
            {
                UserId = user.Id,
                OperationClaimId = operationClaim.Id,
            };
            UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);
            return new()
            {
                Id = addedUserOperationClaim.Id.ToString(),
                OperationClaimName = operationClaim.Name,
                Email = user.Email
            };
        }
    }
}
