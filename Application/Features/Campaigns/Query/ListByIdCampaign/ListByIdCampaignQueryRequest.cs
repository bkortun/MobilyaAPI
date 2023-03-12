using Application.Features.Campaigns.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Query.ListByIdCampaign
{
    public class ListByIdCampaignQueryRequest : IRequest<ListByIdCampaignDto>
    {
        public string Id { get; set; }
    }
}
