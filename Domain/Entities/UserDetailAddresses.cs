using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{//UserDetail ile Address tabloları arası ilişki tablosu.UserDetail ile Address arasında çoka çok ilişki var.
 //UserDetailAddress ile UserDetail arası bire çok ve UserDetailAddress ile Address arası bire çok ilişki var.
    public class UserDetailAddress:Entity
    {
        public Guid UserDetailId { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
