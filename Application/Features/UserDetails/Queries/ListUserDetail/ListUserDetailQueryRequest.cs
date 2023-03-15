using Application.Features.UserDetails.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Queries.ListUserDetail
{
    public class ListUserDetailQueryRequest : IRequest<ListUserDetailModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
