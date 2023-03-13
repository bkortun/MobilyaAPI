using Application.Features.Addresses.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.ListAddress;

public class ListAddressQueryRequest:IRequest<ListAddressModel>
{
    public PageRequest PageRequest { get; set; }
}
