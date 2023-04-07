using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order:Entity
    {
        public Guid BasketId { get; set; }
        public virtual Basket Basket { get; set; }
        public bool Complete { get; set; }
        public bool Cancel { get; set; }

    }
}
