using Application.Features.UserDetails.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Commands.CreateUserDetail
{
    public class CreateUserDetailCommandRequest : IRequest<CreateUserDetailDto>
    {
        public string? PhoneNumber { get; set; }
        //public string AddressId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string UserId { get; set; }
    }
}
