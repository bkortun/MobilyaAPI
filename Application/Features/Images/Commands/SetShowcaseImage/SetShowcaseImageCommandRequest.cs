using Application.Features.Images.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.SetShowcase
{
    public class SetShowcaseImageCommandRequest:IRequest<SetShowcaseImageDto>
    {
        public string ImageId { get; set; }         
        public bool Showcase { get; set; }         
    }
}
