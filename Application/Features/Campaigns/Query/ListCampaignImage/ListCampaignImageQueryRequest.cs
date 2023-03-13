using Application.Features.Campaigns.Dtos;
using Application.Features.Campaigns.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Query.ListCampaignImage
{
    public class ListCampaignImageQueryRequest:IRequest<ListCampaignImageModel>
    {
        public string CampaignId { get; set; }             
    }
}
