using Application.Features.UserDetails.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Queries.ListByIdUserDetail
{
    public class ListByIdUserDetailQueryRequest : IRequest<ListByIdUserDetailDto>
    {
        public string UserId { get; set; } 
    }
}
