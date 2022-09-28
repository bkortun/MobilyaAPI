using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductImage:Entity
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
    }
}
