using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Queries.ListProductProductImage
{
    public class ListProductImageQueryRequest:IRequest<ListProductImageModel>
    {
        public string ProductId { get; set; }
    }
}
