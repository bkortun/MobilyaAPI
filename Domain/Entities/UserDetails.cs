using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserDetail : Entity
    {
        public Guid UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Guid AddressId { get; set; }
        public Guid ProfilePhotoId { get; set; }
        public bool Gender { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserDetailAddress> UserDetailAddresses { get; set; }//UserDetailAddress, UserDetaile bire çok bağlanmış.
    }
}
