using Application.Features.Campaigns.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Query.ListCampaign
{
    public class ListCampaignQueryRequest:IRequest<ListCampaignModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
