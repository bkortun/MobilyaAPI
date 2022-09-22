using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public User(Guid id,string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, DateTime createdDate, DateTime updatedDate, bool status):this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            Status = status;
        }
    }
}
