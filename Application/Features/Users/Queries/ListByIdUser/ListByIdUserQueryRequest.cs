using Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.ListByIdUser
{
    public class ListByIdUserQueryRequest:IRequest<ListByIdUserDto>
    {
        public string Id { get; set; }     
    }
}
