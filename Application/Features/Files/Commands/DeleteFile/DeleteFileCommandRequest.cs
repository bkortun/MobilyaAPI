using Application.Features.Files.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.DeleteFile
{
    public class DeleteFileCommandRequest:IRequest<DeleteFileDto>
    {
        public string FileId { get; set; }         
    }
}
