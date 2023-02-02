using Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RemoveOperationClaim
{
    public class RemoveOperationClaimCommandRequest:IRequest<RemoveOperationClaimDto> 
    {
        public string Id { get; set; }
    }
}
