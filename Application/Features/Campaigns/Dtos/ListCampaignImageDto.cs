using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Dtos
{
    public class ListCampaignImageDto
    {
        public string CampaignId { get; set; }
        public string ImageId { get; set; }
        public string FileId { get; set; }
        public string ImageName { get; set; }
        public string Path { get; set; }
    }
}
