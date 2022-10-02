using Application.Features.ProductImages.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Commands.UploadProductImage
{
    public class UploadProductImageCommandRequest : IRequest<UploadProductImageModel>
    {
        public string ProductId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
