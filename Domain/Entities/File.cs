using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class File:Entity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public virtual Image Image { get; set; }
    }
}
