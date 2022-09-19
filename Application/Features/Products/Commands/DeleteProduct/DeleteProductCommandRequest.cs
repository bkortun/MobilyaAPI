using Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductDto>
    {
        public string Id { get; set; }
    }
}
