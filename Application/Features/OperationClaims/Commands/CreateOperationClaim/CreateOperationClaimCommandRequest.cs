using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using static Domain.Constants.OperationClaims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandRequest : IRequest<CreateOperationClaimDto>
    {
        public string Name { get; set; }
        
    }
}
