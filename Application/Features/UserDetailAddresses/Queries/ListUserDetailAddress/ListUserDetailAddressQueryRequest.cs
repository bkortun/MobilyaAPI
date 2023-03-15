using Application.Features.UserDetailAddresses.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Queries.ListUserDetailAddress
{
    public class ListUserDetailAddressQueryRequest:IRequest<ListUserDetailAddressModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
