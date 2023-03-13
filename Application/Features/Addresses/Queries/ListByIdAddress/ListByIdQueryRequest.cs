using Application.Features.Addresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Query.ListByIdAddress
{
    public class ListByIdAddressQueryRequest : IRequest<ListByIdAddressDto>
    {
        public string Id { get; set; }
    }
}
