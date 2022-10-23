using Application.Features.Orders.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.ListOrder
{
    public class ListOrderQueryRequest:IRequest<ListOrderModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
