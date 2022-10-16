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

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommandRequest, CreateOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo IsRequestedClaimHasExist eklenecek
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);
            CreateOperationClaimDto createOperationClaimDto =_mapper.Map<CreateOperationClaimDto>(addedOperationClaim);
            return createOperationClaimDto;
        }
    }
}
