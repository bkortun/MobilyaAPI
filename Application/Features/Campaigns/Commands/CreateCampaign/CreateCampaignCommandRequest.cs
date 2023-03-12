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
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
    }
}
