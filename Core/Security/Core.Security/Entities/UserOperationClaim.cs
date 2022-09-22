using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class UserOperationClaim:Entity
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

        public UserOperationClaim()
        {

        }

        public UserOperationClaim(Guid id, Guid userId, Guid operationClaimId, DateTime createdDate, DateTime updatedDate, bool status):base(id,createdDate,updatedDate,status)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}
