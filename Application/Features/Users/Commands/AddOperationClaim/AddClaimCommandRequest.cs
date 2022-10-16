using Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.AddOperationClaim
{
    public class AddOperationClaimCommandRequest : IRequest<AddOperationClaimDto>
    {
        public string Email { get; set; }
        public string OperationClaimName { get; set; }
    }
}
