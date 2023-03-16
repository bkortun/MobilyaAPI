using Application.Features.UserDetails.Dtos;
using Application.Features.UserDetails.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Queries.ListProfilePhoto
{
    public class ListProfilePhotoQueryRequest:IRequest<ListProfilePhotoModel>
    {
        public string UserId { get; set; }
    }
}
