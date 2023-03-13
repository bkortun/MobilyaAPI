using Application.Features.Campaigns.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.UploadCampaignImage
{
    public class UploadCampaignImageCommandRequest:IRequest<UploadCampaignImageDto>
    {
        public IFormFileCollection? Files { get; set; }

    }
}
