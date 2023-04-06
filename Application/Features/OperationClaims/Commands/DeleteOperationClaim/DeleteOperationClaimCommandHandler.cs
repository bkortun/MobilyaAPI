using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommandRequest, DeleteOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }
        public async Task<DeleteOperationClaimDto> Handle(DeleteOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo business rule entity mevcutmu kontrolü yapılacak
            OperationClaim operationClaim =await _operationClaimRepository.GetAsync(o=>o.Id==Guid.Parse(request.Id));
            OperationClaim deletedOperationClaim=await _operationClaimRepository.DeleteAsync(operationClaim);
            DeleteOperationClaimDto deleteOperationClaimDto =_mapper.Map<DeleteOperationClaimDto>(operationClaim);
            return deleteOperationClaimDto;
        }
    }
}
