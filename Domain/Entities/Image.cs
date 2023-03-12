using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image:Entity
    {
        public Guid FileId { get; set; }
        public bool Showcase { get; set; }
        public virtual File File { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
