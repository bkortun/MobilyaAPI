using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public Entity()
        {

        }

        public Entity(Guid id, DateTime createdDate, DateTime updatedDate, bool status)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            Status = status;
        }
    }
}
