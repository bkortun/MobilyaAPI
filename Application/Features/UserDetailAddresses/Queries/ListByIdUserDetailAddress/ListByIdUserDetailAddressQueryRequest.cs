using Application.Features.UserDetailAddresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Queries.ListByIdUserDetailAddress
{
    public class ListByIdUserDetailAddressQueryRequest:IRequest<ListByIdUserDetailAddressDto>
    {
        public string Id { get; set; }

    }
}
