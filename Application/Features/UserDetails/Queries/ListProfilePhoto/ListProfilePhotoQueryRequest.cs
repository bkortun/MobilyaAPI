using Application.Features.UserDetails.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Queries.ListProfilePhoto
{
    public class ListProfilePhotoQueryRequest:IRequest<ListProfilePhotoDto>
    {
        public string UserId { get; set; }
    }
}
