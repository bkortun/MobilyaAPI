using Application.Features.Images.Dtos;
using Application.Features.Images.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.Upload
{
    public class UploadImageCommandRequest:IRequest<UploadImageModel>
    {
        public IFormFileCollection? Files { get; set; }
    }
}
