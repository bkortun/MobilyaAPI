using Application.Features.Users.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.ListOperationClaimByUserEmail
{
    public class ListOperationClaimByUserEmailQueryRequest:IRequest<ListOperationClaimByUserEmailModel>
    {
        public string Email { get; set; }
    }
}
