using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class OperationClaim:Entity
    {
        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public OperationClaim()
        {

        }

        public OperationClaim(Guid id,string name,DateTime createdDate,DateTime updatedDate,bool status):base(id,createdDate,updatedDate,status)
        {
            Name = name;
        }
    }
}
