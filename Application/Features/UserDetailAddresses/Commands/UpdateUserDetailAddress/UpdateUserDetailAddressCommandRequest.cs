using Application.Features.UserDetailAddresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Commands.UpdateUserDetailAddress
{
    public class UpdateUserDetailAddressCommandRequest : IRequest<UpdateUserDetailAddressDto>
    {
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
