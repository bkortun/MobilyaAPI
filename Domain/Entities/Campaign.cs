using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Campaign : Entity
    {
        public string CampaignName { get; set; }
        public Guid ImageId { get; set; }
        public string CampaignDescription { get; set; }
        public virtual Image Image { get; set; }
    }
}
