using Application.Features.Campaigns.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Models
{
    public class ListCampaignImageModel:BasePageableModel
    {
        public List<ListCampaignImageDto> Items { get; set; }
    }
}
