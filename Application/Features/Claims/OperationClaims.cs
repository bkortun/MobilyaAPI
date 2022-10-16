using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.ListOperationClaim;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Claims
{
    public class OperationClaims
    {
        private readonly IMediator _mediator;

        public OperationClaims(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string[]> GetClaimsAsync()
        {
            ListOperationClaimQueryRequest listOperationClaimQueryRequest = new()
            {
                PageRequest = new PageRequest { Page=0,PageSize =100}
            };
            ListOperationClaimModel response = await _mediator.Send(listOperationClaimQueryRequest);
            return response.Items.Select(x=>x.Name).ToArray();
        }
    }
}
