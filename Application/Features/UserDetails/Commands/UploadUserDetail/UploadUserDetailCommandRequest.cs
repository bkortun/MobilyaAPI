using Application.Features.UserDetails.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Commands.UploadUserDetail
{
    public class UploadUserDetailCommandRequest:IRequest<UploadUserDetailDto>
    {
        public string UserId { get; set; }
        public IFormFileCollection? ProfilePhoto { get; set; }
    }
}
