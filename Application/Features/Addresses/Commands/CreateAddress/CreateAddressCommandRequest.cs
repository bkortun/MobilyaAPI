using Application.Features.Addresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandRequest:IRequest<CreateAddressDto>
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
