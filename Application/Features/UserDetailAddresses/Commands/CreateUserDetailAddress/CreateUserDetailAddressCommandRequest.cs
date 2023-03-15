using Application.Features.UserDetailAddresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Commands.CreateUserDetailAddress
{
    public class CreateUserDetailAddressCommandRequest:IRequest<CreateUserDetailAddressDto>
    {
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
