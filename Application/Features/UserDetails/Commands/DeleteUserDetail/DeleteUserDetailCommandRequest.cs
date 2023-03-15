using Application.Features.UserDetails.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Commands.DeleteUserDetail
{
    public class DeleteUserDetailCommandRequest : IRequest<DeleteUserDetailDto>
    {
        public string Id { get; set; }
    }
}
