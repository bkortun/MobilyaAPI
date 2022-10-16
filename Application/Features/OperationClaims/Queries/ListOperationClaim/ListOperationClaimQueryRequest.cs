using Application.Features.OperationClaims.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.ListOperationClaim
{
    public class ListOperationClaimQueryRequest:IRequest<ListOperationClaimModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
