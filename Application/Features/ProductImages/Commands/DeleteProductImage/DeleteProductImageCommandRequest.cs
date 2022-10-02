using Application.Features.ProductImages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandRequest:IRequest<DeleteProductImageDto>
    {
        public string FileId { get; set; }
    }
}
