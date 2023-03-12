using Application.Features.Campaigns.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.UpdateCampaign
{
    public class UpdateCampaignCommandRequest:IRequest<UpdateCampaignDto>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
