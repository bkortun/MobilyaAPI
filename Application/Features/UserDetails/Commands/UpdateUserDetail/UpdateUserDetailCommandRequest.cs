using Application.Features.UserDetails.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Commands.UpdateUserDetail
{
    public class UpdateUserDetailCommandRequest : IRequest<UpdateUserDetailDto>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePhotoId { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
