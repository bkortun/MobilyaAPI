using Application.Features.Campaigns.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.CreateCampaign
{
    public class CreateCampaignCommandRequest : IRequest<CreateCampaignDto>
    {
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        //public Guid ImageId { get; set; }
    }
}
