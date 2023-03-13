using Application.Features.Addresses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandRequest:IRequest<DeleteAddressDto>
    {
        //abi burada verdiğin prop adında isim vermen lazım
        public string Id { get; set; }
    }
}
