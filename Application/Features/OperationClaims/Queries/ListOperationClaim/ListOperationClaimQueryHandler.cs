using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.ListOperationClaim
{
    public class ListOperationClaimQueryHandler : IRequestHandler<ListOperationClaimQueryRequest, ListOperationClaimModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public ListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<ListOperationClaimModel> Handle(ListOperationClaimQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
            ListOperationClaimModel listOperationClaimModel =_mapper.Map<ListOperationClaimModel>(operationClaims);
            return listOperationClaimModel;

        }
    }
}
